using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.Mail;
using System.IO;
using System.Drawing.Imaging;
using Phumla_Kamnandi;
using Phumpla_Kamnandi.Application;
using System.Runtime.InteropServices.ComTypes;

namespace Phumpla_Kamnandi.View
{
    public partial class OccupancyReportForm : Form
    {
        private RoomAllocationController roomAllocationController;
        private ReservationController reservationController;
        private EmployeeController employeeController;
        private string employeeID;
        private Employee currentEmployee;
        private Chart occupancyChart;
        private Chart salesChart;
        private Chart operationalChart;
        private TabControl reportstabControl;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private Button generateReportButton;
        private Button sendReportButton;

        public OccupancyReportForm(string employeeID)
        {
            InitializeComponent();
            roomAllocationController = new RoomAllocationController();
            reservationController = new ReservationController();
            employeeController = new EmployeeController();
            this.employeeID = employeeID;
            this.currentEmployee = SessionManager.CurrentEmployee;

            InitializeFormComponents();
            InitializeCharts();
        }

        private void InitializeFormComponents()
        {
            this.Size = new System.Drawing.Size(800, 600);

            startDatePicker = new DateTimePicker();
            startDatePicker.Location = new System.Drawing.Point(50, 30);
            startDatePicker.Format = DateTimePickerFormat.Short;
            this.Controls.Add(startDatePicker);

            endDatePicker = new DateTimePicker();
            endDatePicker.Location = new System.Drawing.Point(350, 30);
            endDatePicker.Format = DateTimePickerFormat.Short;
            this.Controls.Add(endDatePicker);

            generateReportButton = new Button();
            generateReportButton.Text = "Generate Report";
            generateReportButton.Location = new System.Drawing.Point(650, 30);
            generateReportButton.Click += GenerateReportButton_Click;
            this.Controls.Add(generateReportButton);

            reportstabControl = new TabControl();
            reportstabControl.Location = new System.Drawing.Point(50, 70);
            reportstabControl.Size = new System.Drawing.Size(700, 450);
            reportstabControl.Visible = false;
            this.Controls.Add(reportstabControl);

            reportstabControl.TabPages.Add("Occupancy");

            if (currentEmployee.Position.ToLower() == "manager") {
                reportstabControl.TabPages.Add("Sales");
                reportstabControl.TabPages.Add("Operational");
            }
           
            sendReportButton = new Button();
            sendReportButton.Text = "Send Report";
            sendReportButton.Location = new System.Drawing.Point(650, 530);
            sendReportButton.Size = new System.Drawing.Size(100, 30);
            sendReportButton.Click += SendReportButton_Click;
            this.Controls.Add(sendReportButton);

            Button backButton = new Button();
            backButton.Text = "Back";
            backButton.Location = new System.Drawing.Point(550, 530);
            backButton.Size = new System.Drawing.Size(100, 30);
            backButton.Click += BackButton_Click;
            this.Controls.Add(backButton);
        }

        private void InitializeCharts()
        {
            occupancyChart = CreateChart("Occupancy Report");
            reportstabControl.TabPages[0].Controls.Add(occupancyChart); ;

            if (currentEmployee.Position.ToLower() == "manager") {
                salesChart = CreateChart("Sales Report");
                operationalChart = CreateChart("Operational Efficiency Report");
                reportstabControl.TabPages[1].Controls.Add(salesChart);
                reportstabControl.TabPages[2].Controls.Add(operationalChart);
            }
        }

        private Chart CreateChart(string title)
        {
            Chart chart = new Chart();
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);
            chart.Dock = DockStyle.Fill;
            chart.Titles.Add(title);
            return chart;
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = startDatePicker.Value;
            DateTime endDate = endDatePicker.Value;

            GenerateOccupancyReport(startDate, endDate);

            if (currentEmployee.Position.ToLower() == "manager") {
                GenerateSalesReport(startDate, endDate);
                GenerateOperationalReport(startDate, endDate);
            }
            
            reportstabControl.Visible = true;
            reportstabControl.SelectedIndex = 0; // Show Occupancy report by default
        }

        private void GenerateOccupancyReport(DateTime startDate, DateTime endDate)
        {
            var allocatedRooms = roomAllocationController.GetAllocatedRooms(startDate, endDate);
            int totalRooms = 5; // Assume 5 total rooms, adjust as needed

            occupancyChart.Series.Clear();
            Series series = new Series("Occupancy Level");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.Red;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                int occupiedRooms = allocatedRooms.Count(a => a.CheckInDate <= date && a.CheckOutDate >= date);
                decimal occupancyRate = (decimal)occupiedRooms / totalRooms * 100;
                series.Points.AddXY(date.ToShortDateString(), occupancyRate);
            }

            occupancyChart.Series.Add(series);
            occupancyChart.ChartAreas[0].AxisY.Maximum = 100;
            occupancyChart.ChartAreas[0].AxisY.Title = "Occupancy Rate (%)";
            occupancyChart.ChartAreas[0].AxisX.Title = "Date";
        }

        private void GenerateSalesReport(DateTime startDate, DateTime endDate)
        {
            var reservations = reservationController.AllReservations;

            salesChart.Series.Clear();
            Series series = new Series("Daily Sales");
            series.ChartType = SeriesChartType.Line;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                decimal dailySales = reservations
                    .Where(r => r.CheckInDate <= date && r.CheckOutDate > date && r.Status == "Confirmed")
                    .Sum(r => r.TotalAmount / (r.CheckOutDate - r.CheckInDate).Days);

                series.Points.AddXY(date.ToShortDateString(), dailySales);
            }

            salesChart.Series.Add(series);
            salesChart.ChartAreas[0].AxisY.Title = "Daily Sales (R)";
            salesChart.ChartAreas[0].AxisX.Title = "Date";
        }

        private void GenerateOperationalReport(DateTime startDate, DateTime endDate)
        {
            var allocatedRooms = roomAllocationController.GetAllocatedRooms(startDate, endDate);
            int totalRooms = 5;

            operationalChart.Series.Clear();
            Series occupancySeries = new Series("Occupancy Rate");
            occupancySeries.ChartType = SeriesChartType.Line;
            occupancySeries.Color = Color.Red;

            Series turnoverSeries = new Series("Room Turnover");
            turnoverSeries.ChartType = SeriesChartType.Line;
            occupancySeries.Color = Color.Blue;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                int occupiedRooms = allocatedRooms.Count(a => a.CheckInDate <= date && a.CheckOutDate >= date);
                decimal occupancyRate = (decimal)occupiedRooms / totalRooms * 100;

                int checkIns = allocatedRooms.Count(a => a.CheckInDate == date);
                int checkOuts = allocatedRooms.Count(a => a.CheckOutDate == date);
                decimal turnoverRate = (decimal)(checkIns + checkOuts) / totalRooms * 100;

                occupancySeries.Points.AddXY(date.ToShortDateString(), occupancyRate);
                turnoverSeries.Points.AddXY(date.ToShortDateString(), turnoverRate);
            }

            operationalChart.Series.Add(occupancySeries);
            operationalChart.Series.Add(turnoverSeries);
            operationalChart.ChartAreas[0].AxisY.Maximum = 100;
            operationalChart.ChartAreas[0].AxisY.Title = "Rate (%)";
            operationalChart.ChartAreas[0].AxisX.Title = "Date";
        }

        private void SendReportButton_Click(object sender, EventArgs e)
        {
            GenerateReportPreview();
        }

        private void GenerateReportPreview()
        {
            var allocatedRooms = roomAllocationController.GetAllocatedRooms(startDatePicker.Value, endDatePicker.Value);
            var reservations = reservationController.AllReservations;

            DateTime earliestDate = allocatedRooms.Min(a => a.CheckInDate);
            DateTime latestDate = allocatedRooms.Max(a => a.CheckOutDate);

            DateTime reservationStartDate = reservations.Min(r => r.CheckInDate);
            DateTime reservationEndDate = reservations.Max(r => r.CheckOutDate);

            if (reservationStartDate < earliestDate) earliestDate = reservationStartDate;
            if (reservationEndDate > latestDate) latestDate = reservationEndDate;

            Form previewForm = new Form
            {
                Text = "Report Preview",
                Size = new Size(800,900),
                AutoScroll = true
            };

            Panel reportPanel = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(20)
            };
            previewForm.Controls.Add(reportPanel);

            int yPos = 20;

            AddLabel(reportPanel, "Operational Report", new Font("Arial", 18, FontStyle.Bold), ref yPos);

            Employee preparedBy = currentEmployee;
            AddLabel(reportPanel, $"Prepared by: {preparedBy.FirstName} {preparedBy.LastName}", new Font("Arial", 12), ref yPos);

            AddLabel(reportPanel, $"Date prepared: {DateTime.Now.ToShortDateString()}", new Font("Arial", 12), ref yPos);

            AddLabel(reportPanel, $"Report ID: OCC-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}", new Font("Arial", 12), ref yPos);

            AddLabel(reportPanel, "Description: This report shows the occupancy, sales, and operational metrics for the selected period.", new Font("Arial", 12), ref yPos);

            AddLabel(reportPanel, $"Period: {earliestDate.ToShortDateString()} - {latestDate.ToShortDateString()}", new Font("Arial", 12), ref yPos);

            yPos += 20;

            AddOccupancySummary(reportPanel, ref yPos);

            AddChartToPanel(reportPanel, occupancyChart, ref yPos);
            AddDataGridView(reportPanel, GetChartData(occupancyChart), ref yPos);

            AddChartToPanel(reportPanel, salesChart, ref yPos);
            AddDataGridView(reportPanel, GetChartData(salesChart), ref yPos);

            AddChartToPanel(reportPanel, operationalChart, ref yPos);
            AddDataGridView(reportPanel, GetChartData(operationalChart), ref yPos);

            yPos += 20;

            TextBox emailTextBox = new TextBox
            {
                Location = new Point(20, yPos),
                Width = 300,
                
            };
            reportPanel.Controls.Add(emailTextBox);

            Button sendButton = new Button
            {
                Text = "Send Report",
                Location = new Point(350, yPos),
                Size = new Size(100, 30)
            };
            sendButton.Click += (s, e) =>
            {
                SendReportByEmail(emailTextBox.Text, reportPanel);
                previewForm.Close();
            };
            reportPanel.Controls.Add(sendButton);

            previewForm.ShowDialog();
        }

        private void AddOccupancySummary(Panel panel, ref int yPos)
        {
            AddLabel(panel, "Occupancy Summary", new Font("Arial", 14, FontStyle.Bold), ref yPos);

            var occupancyRanges = new Dictionary<string, int>
            {
                {"0% - 20%", 0},
                {"21% - 40%", 0},
                {"41% - 60%", 0},
                {"61% - 80%", 0},
                {"81% - 100%", 0}
            };

            foreach (var point in occupancyChart.Series[0].Points)
            {
                double occupancy = point.YValues[0];
                string range = GetOccupancyRange(occupancy);
                occupancyRanges[range]++;
            }

            int totalDays = occupancyChart.Series[0].Points.Count;

            foreach (var range in occupancyRanges)
            {
                double percentage = (double)range.Value / totalDays * 100;
                AddLabel(panel, $"{range.Key}: {percentage:F2}% of the time", new Font("Arial", 12), ref yPos);
            }

            yPos += 20;
        }

        private string GetOccupancyRange(double occupancy)
        {
            if (occupancy <= 20) return "0% - 20%";
            if (occupancy <= 40) return "21% - 40%";
            if (occupancy <= 60) return "41% - 60%";
            if (occupancy <= 80) return "61% - 80%";
            return "81% - 100%";
        }

        private void AddChartToPanel(Panel panel, Chart chart, ref int yPos)
        {
            Chart previewChart = new Chart
            {
                Size = new Size(700, 400),
                Location = new Point(20, yPos)
            };
            ChartArea chartArea = new ChartArea();
            previewChart.ChartAreas.Add(chartArea);

            chartArea.AxisX.Title = chart.ChartAreas[0].AxisX.Title;
            chartArea.AxisY.Title = chart.ChartAreas[0].AxisY.Title;
            chartArea.AxisY.Maximum = chart.ChartAreas[0].AxisY.Maximum;

            foreach (Series series in chart.Series)
            {
                previewChart.Series.Add(CopyChartSeries(series));
            }

            panel.Controls.Add(previewChart);
            yPos += previewChart.Height + 40;
        }

        private void AddDataGridView(Panel panel, List<(string, double)> data, ref int yPos)
        {
            DataGridView dataGridView = new DataGridView
            {
                Width = 700,
                Height = 150,
                Location = new Point(20, yPos),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            };

            dataGridView.Columns.Add("Date", "Date");
            dataGridView.Columns.Add("Value", "Value");

            foreach (var (date, value) in data)
            {
                dataGridView.Rows.Add(date, value);
            }

            panel.Controls.Add(dataGridView);
            yPos += dataGridView.Height + 20;
        }

        private List<(string, double)> GetChartData(Chart chart)
        {
            List<(string, double)> chartData = new List<(string, double)>();

            foreach (DataPoint point in chart.Series[0].Points)
            {
                string date = point.AxisLabel;
                double value = point.YValues[0];
                chartData.Add((date, value));
            }

            return chartData;
        }

        private void AddLabel(Panel panel, string text, Font font, ref int yPos)
        {
            Label label = new Label
            {
                Text = text,
                Font = font,
                AutoSize = true,
                Location = new Point(20, yPos)
            };
            panel.Controls.Add(label);
            yPos += label.Height + 10;
        }

        private Series CopyChartSeries(Series originalSeries)
        {
            Series newSeries = new Series(originalSeries.Name)
            {
                ChartType = originalSeries.ChartType
            };
            foreach (DataPoint point in originalSeries.Points)
            {
                newSeries.Points.AddXY(point.AxisLabel, point.YValues[0]);
            }
            return newSeries;
        }

        private void SendReportByEmail(string recipientEmail, Panel reportPanel)
        {
            try
            {
                // Create a bitmap of the report panel
                Bitmap reportImage = new Bitmap(reportPanel.Width, reportPanel.Height);
                reportPanel.DrawToBitmap(reportImage, new Rectangle(0, 0, reportPanel.Width, reportPanel.Height));

                // Save the bitmap to a temporary file
                string tempImagePath = Path.GetTempFileName() + ".png";
                reportImage.Save(tempImagePath, ImageFormat.Png);

                // Create the email message
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("phumlakamnandi7@gmail.com");
                mail.To.Add(recipientEmail);
                mail.Subject = "Occupancy Level Report";
                mail.Body = "Please find attached the Occupancy Level Report.";

                // Attach the report image
                Attachment attachment = new Attachment(tempImagePath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("phumlakamnandi7@gmail.com", "uibi ejjc efms hqaj");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                // Clean up
                attachment.Dispose();
                File.Delete(tempImagePath);

                MessageBox.Show("Report sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            HomePage homepage = new HomePage();

            homepage.MdiParent = this.MdiParent;
            homepage.StartPosition = FormStartPosition.CenterScreen;
            homepage.WindowState = FormWindowState.Normal;
            homepage.Show();

            this.Close();
        }

        private void OccupancyReportForm_Load(object sender, EventArgs e)
        {
            // Any initialization code for when the form loads
        }
    }
}