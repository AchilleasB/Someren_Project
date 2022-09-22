using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenModel;
using SomerenLogic;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        // TODO: find a better way to pass the value between two instances of the same class (static field?)
        Drink selectedDrinkFromListView = null;
        Activity selectedActivityFromListView = null;

        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");

            //Limiting the date period to past dates only
            dateTimePickerStartDate.MaxDate = DateTime.Now;
            dateTimePickerEndDate.MaxDate = DateTime.Now.AddDays(1);
        }

        private void showPanel(string panelName)
        {
            if (panelName == "Dashboard")
            {
                // hide all other panels
                pnlStudents.Hide();
                TeacherPanel.Hide();
                pnlRooms.Hide();
                pnlDrinks.Hide();
                pnlSales.Hide();
                pnlRevenueReport.Hide();
                pnlActivities.Hide();
                pnlActivParticipants.Hide();
                panel1.Hide();


                // show dashboard
                pnlDashboard.Show();
                imgDashboard.Show();
            }
            else if (panelName == "RevenueReport")
            {
                pnlDashboard.Hide();
                imgDashboard.Hide();
                TeacherPanel.Hide();
                pnlRooms.Hide();
                pnlStudents.Hide();
                pnlDrinks.Hide();
                pnlSales.Hide();
                pnlActivities.Hide();
                pnlActivParticipants.Hide();
                panel1.Hide();

                // hide all other panels


                // show revenue report
                pnlRevenueReport.Show();
                pnlRevenueReport.Dock = DockStyle.Fill;
            }
            else if (panelName == "Supervisors")
            {
                // hide all other panels
                pnlRevenueReport.Hide();
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlStudents.Hide();
                pnlRooms.Hide();
                pnlDrinks.Hide();
                pnlSales.Hide();
                pnlDrinksListAll.Hide();
                pnlActivParticipants.Hide();
                pnlAddDrink.Hide();
                pnlUpdateDrink.Hide();
                TeacherPanel.Hide();
                


                // show students
                panel1.Show();
                panel1.Dock = DockStyle.Fill;
                try
                {
                    // fill the students listview within the students panel with a list of students
                    SupervisorActivityService superService = new SupervisorActivityService(); ;
                    List<Activity> activityList = superService.GetAllActivities(); ;

                    // clear the listview before filling it again
                    listView1.Clear();

                    listView1.View = View.Details;
                    listView1.FullRowSelect = true;
                    listView1.Columns.Add("Activity Id", 100);
                    listView1.Columns.Add("Activity", 200);

                    foreach (Activity t in activityList)
                    {
                        string[] activityArray = { t.Id.ToString(), t.Description };
                        ListViewItem li = new ListViewItem(activityArray);
                        listView1.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the supervisors: " + e.Message);
                }

            }
            else if (panelName == "Sales Point")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                TeacherPanel.Hide();
                pnlRooms.Hide();
                pnlStudents.Hide();
                pnlDrinks.Hide();
                pnlRevenueReport.Hide();
                pnlActivities.Hide();
                pnlActivParticipants.Hide();
                panel1.Hide();

                // show sales point
                pnlSales.Show();
                pnlSales.Dock = DockStyle.Fill;

                DisplaySalesListViews();

            }
            else if (panelName == "Students")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                TeacherPanel.Hide();
                pnlRooms.Hide();
                pnlDrinks.Hide();
                pnlSales.Hide();
                pnlActivities.Hide();
                pnlActivParticipants.Hide();

                // show students
                pnlStudents.Show();
                pnlStudents.Dock = DockStyle.Fill;
                try
                {
                    // fill the students listview within the students panel with a list of students
                    StudentService studService = new StudentService(); ;
                    List<Student> studentList = studService.GetStudents(); ;

                    // clear the listview before filling it again
                    listViewStudents.Clear();
                    listViewStudents.View = View.Details;
                    listViewStudents.FullRowSelect = true;
                    listViewStudents.Columns.Add("Student Id", 255);
                    listViewStudents.Columns.Add("Student Name", 255);
                    listViewStudents.Columns.Add("Student Date Of Birth", 255);

                    foreach (Student s in studentList)
                    {
                        string[] studentArray = { s.Number.ToString(), s.Name, s.BirthDate.ToString("yyyy/MM/dd") };
                        ListViewItem li = new ListViewItem(studentArray);
                        listViewStudents.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                }
            }
            else if (panelName == "Rooms")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                TeacherPanel.Hide();
                pnlStudents.Hide();
                pnlDrinks.Hide();
                pnlSales.Hide();
                pnlActivities.Hide();
                pnlDrinksListAll.Hide();
                pnlAddDrink.Hide();
                pnlUpdateDrink.Hide();
                pnlActivParticipants.Hide();

                // show rooms panel
                pnlRooms.Show();
                pnlRooms.Dock = DockStyle.Fill;
                try
                {
                    RoomService roomService = new RoomService(); ;
                    List<Room> roomList = roomService.GetRooms(); ;

                    // clear the listview before filling it again
                    listViewRooms.Clear();
                    listViewRooms.View = View.Details;
                    listViewRooms.FullRowSelect = true;
                    listViewRooms.Columns.Add("Room Number", 255);
                    listViewRooms.Columns.Add("Capacity", 255);
                    listViewRooms.Columns.Add("Room Type", 255);

                    foreach (Room r in roomList)
                    {
                        string[] roomArray = { r.Number.ToString(), r.Capacity.ToString(), r.Type.ToString() };
                        ListViewItem li = new ListViewItem(roomArray);
                        listViewRooms.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the rooms: " + e.Message);
                }
            }
            else if (panelName == "Teachers")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlStudents.Hide();
                pnlRooms.Hide();
                pnlDrinks.Hide();
                pnlSales.Hide();
                pnlDrinks.Hide();
                pnlActivities.Hide();
                pnlDrinksListAll.Hide();
                pnlAddDrink.Hide();
                pnlUpdateDrink.Hide();
                pnlActivParticipants.Hide();

                // show students
                TeacherPanel.Show();
                TeacherPanel.Dock = DockStyle.Fill;
                try
                {
                    // fill the students listview within the students panel with a list of students
                    TeacherService teachService = new TeacherService(); ;
                    List<Teacher> teacherList = teachService.GetTeachers(); ;

                    // clear the listview before filling it again
                    listViewTeachers.Clear();

                    listViewTeachers.View = View.Details;
                    listViewTeachers.FullRowSelect = true;
                    listViewTeachers.Columns.Add("ID", 50);
                    listViewTeachers.Columns.Add("Lecturer Name", 255);
                    listViewTeachers.Columns.Add("Lecturer Surname", 255);
                    listViewTeachers.Columns.Add("Supervisor", 255);

                    foreach (Teacher t in teacherList)
                    {
                        string[] nameAndSurname = t.Name.Split(' ');

                        string[] teacherArray = { t.Number.ToString(), nameAndSurname[0], nameAndSurname[1], t.Supervisor };
                        ListViewItem li = new ListViewItem(teacherArray);
                        listViewTeachers.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the teachers: " + e.Message);
                }
            }
            else if (panelName == "Drinks")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlStudents.Hide();
                pnlRooms.Hide();
                TeacherPanel.Hide();
                pnlSales.Hide();
                pnlActivities.Hide();
                pnlActivParticipants.Hide();

                // hide picture boxes in other panels
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();

                // show all drinks
                pnlDrinks.Show();
                pnlDrinks.Dock = DockStyle.Fill;
            }
            else if (panelName == "ListAllDrinks")
            {
                // hide all other panels
                pnlAddDrink.Hide();
                pnlUpdateDrink.Hide();
                pnlSales.Hide();
                pnlActivParticipants.Hide();

                // show all drinks
                pnlDrinksListAll.Show();
                pnlDrinksListAll.Dock = DockStyle.Fill;
                try
                {
                    // fill the drinks listview within the drinks panel with a list of drinks
                    DrinkService drinkService = new DrinkService();
                    List<Drink> drinkList = drinkService.GetDrinks();

                    //// clear the listview before filling it again
                    listViewDrinks.Clear();

                    listViewDrinks.View = View.Details;
                    listViewDrinks.FullRowSelect = true;
                    listViewDrinks.Columns.Add("Id");
                    listViewDrinks.Columns.Add("Drink Name", 100);
                    listViewDrinks.Columns.Add("Alcoholic");
                    listViewDrinks.Columns.Add("Price");
                    listViewDrinks.Columns.Add("Stock");
                    listViewDrinks.Columns.Add("Status", 150);
                    listViewDrinks.Columns.Add("Sold");

                    string isAlcoholic, stockStatus;
                    foreach (Drink d in drinkList)
                    {
                        // if alcoholic drink show yes, otherwise no
                        isAlcoholic = d.isAlcoholic ? "yes" : "no";

                        // check stock status
                        stockStatus = d.Stock >= 10 ? "Stock sufficient" : "Stock nearly depleted";

                        string[] drinkArray = { d.Id.ToString(), d.Name, isAlcoholic, d.Price.ToString(), d.Stock.ToString(), stockStatus, d.Sold.ToString() };
                        ListViewItem li = new ListViewItem(drinkArray);
                        listViewDrinks.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the drinks: " + e.Message);
                }
            }
            else if (panelName == "AddDrink")
            {
                // hide all other panels
                pnlDrinksListAll.Hide();
                pnlUpdateDrink.Hide();
                //pnlSales.Hide();
                pnlSales.Hide();
                pnlActivParticipants.Hide();

                // show add drink panel
                pnlAddDrink.Show();
                pnlAddDrink.Dock = DockStyle.Fill;
            }
            else if (panelName == "UpdateDrink")
            {
                // hide all other panels
                pnlDrinksListAll.Hide();
                pnlAddDrink.Hide();

                pnlSales.Hide();
                pnlActivParticipants.Hide();
                // show update drink panel
                pnlUpdateDrink.Show();
                pnlUpdateDrink.Dock = DockStyle.Fill;

                // show drink data if any drink is selected
                if (selectedDrinkFromListView != null)
                {
                    txtBoxUpdateDrinkName.Text = selectedDrinkFromListView.Name;
                    txtBoxUpdateDrinkPrice.Text = selectedDrinkFromListView.Price.ToString();
                    chkBoxUpdateDrinkType.Checked = (bool)selectedDrinkFromListView.isAlcoholic;
                    txtBoxUpdateDrinkStock.Text = selectedDrinkFromListView.Stock.ToString();
                    txtBoxUpdateDrinkSold.Text = selectedDrinkFromListView.Sold.ToString();
                }
            }
            else if (panelName == "Activity Participants")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlStudents.Hide();
                pnlRooms.Hide();
                TeacherPanel.Hide();
                pnlDrinksListAll.Hide();
                pnlAddDrink.Hide();
                pnlUpdateDrink.Hide();
                pnlSales.Hide();
                pnlRevenueReport.Hide();
                panel1.Hide();

                // show activity participants panel
                pnlActivParticipants.Show();
                pnlActivParticipants.Dock = DockStyle.Fill;
                try
                {
                    // fill the activity list within the ActivityParticipants panel with a list of activities
                    ActivityStudentService activService = new ActivityStudentService();
                    List<Activity> activList = activService.GetActivities();

                    //// clear the listviews before filling them in again
                    lstViewActivities.Clear();
                    lstViewActivities.View = View.Details;
                    lstViewActivities.FullRowSelect = true;
                    lstViewActivities.Columns.Add("ActivityId");
                    lstViewActivities.Columns.Add("Description", 100);
                    lstViewActivities.Columns.Add("Start Date-Time", 125);
                    lstViewActivities.Columns.Add("End Date-Time", 125);

                    lstViewParticipants.Clear();
                    lstViewParticipants.View = View.Details;
                    lstViewParticipants.FullRowSelect = true;
                    lstViewParticipants.Columns.Add("StudentId");
                    lstViewParticipants.Columns.Add("StudentName", 100);

                    lstViewNonParticipants.Clear();
                    lstViewNonParticipants.View = View.Details;
                    lstViewNonParticipants.FullRowSelect = true;
                    lstViewNonParticipants.Columns.Add("StudentId");
                    lstViewNonParticipants.Columns.Add("StudentName", 100);

                    foreach (Activity activ in activList)
                    {
                        string[] activityArray = { activ.Id.ToString(), activ.Description, activ.StartDateTime.ToString(), activ.EndDateTime.ToString() };
                        ListViewItem item = new ListViewItem(activityArray);
                        item.Tag = activ;
                        lstViewActivities.Items.Add(item);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
                }
            }
            else if (panelName == "Activities")
            {

                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlStudents.Hide();
                pnlRooms.Hide();
                TeacherPanel.Hide();
                pnlDrinks.Hide();
                pnlSales.Hide();
                pnlRevenueReport.Hide();

                // hide picture boxes in other panels
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();

                // show all drinks
                pnlActivities.Show();
                pnlActivities.Dock = DockStyle.Fill;
            }
            else if (panelName == "ListAllActivities")
            {
                // reset selected activity when activity list render since it's the goto panel after
                // cancel add new activity, submit/cancel update, submit/cancel delete
                selectedActivityFromListView = null;

                // hide all other panels
                pnlActivityAdd.Hide();
                pnlActivityUpdate.Hide();

                // show all drinks
                pnlActivitiesListAll.Show();
                pnlActivitiesListAll.Dock = DockStyle.Fill;
                try
                {
                    // fill the activities listview within the activities panel with a list of activities
                    ActivityService activityService = new ActivityService();
                    List<Activity> activityList = activityService.GetActivities();

                    //// clear the listview before filling it again
                    listViewActivities.Clear();

                    listViewActivities.View = View.Details;
                    listViewActivities.FullRowSelect = true;
                    listViewActivities.Columns.Add("Id");
                    listViewActivities.Columns.Add("Description", 100);
                    listViewActivities.Columns.Add("Start date and time", 150);
                    listViewActivities.Columns.Add("End date and time", 150);

                    foreach (Activity a in activityList)
                    {
                        string[] activity = { a.Id.ToString(), a.Description, a.StartDateTime.ToString("yyyy-MM-dd  HH:mm"), a.EndDateTime.ToString("yyyy-MM-dd  HH:mm") };
                        ListViewItem li = new ListViewItem(activity);
                        listViewActivities.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
                }
            }
            else if (panelName == "AddActivity")
            {
                // hide all other panels
                pnlActivitiesListAll.Hide();
                pnlActivityUpdate.Hide();

                // show add activity panel
                pnlActivityAdd.Show();
                pnlActivityAdd.Dock = DockStyle.Fill;

                // reset
                resetFields("updateActivity");
            }
            else if (panelName == "UpdateActivity")
            {
                // hide all other panels
                pnlActivitiesListAll.Hide();
                pnlActivityAdd.Hide();

                // show update drink panel
                pnlActivityUpdate.Show();
                pnlActivityUpdate.Dock = DockStyle.Fill;

                // show drink data if any drink is selected
                if (selectedActivityFromListView != null)
                {
                    txtBoxActivityUpdateDescription.Text = selectedActivityFromListView.Description;
                    dtpActivityUpdateStartDate.Value = selectedActivityFromListView.StartDateTime;
                    dtpActivityUpdateEndDate.Value = selectedActivityFromListView.EndDateTime;
                }

            }
        }

        // reset drink fields
        public void resetFields(string action)
        {
            if (action == "addDrink")
            {
                txtBoxDrinkName.Text = "";
                txtBoxDrinkPrice.Text = "";
                chkBoxDrinkType.Checked = false;
                txtBoxStock.Text = "";
                txtBoxAddDrinkSold.Text = "";
            }
            else if (action == "updateDrink")
            {
                txtBoxUpdateDrinkName.Text = "";
                txtBoxUpdateDrinkPrice.Text = "";
                chkBoxUpdateDrinkType.Checked = false;
                txtBoxUpdateDrinkStock.Text = "";
                txtBoxUpdateDrinkSold.Text = "";
            }
            else if (action == "addActivity")
            {
                txtBoxActivityAddDescription.Text = "";
                dtpActivityAddStartDate.Value = DateTime.Now;
                dtpActivityAddEndDate.Value = DateTime.Now;
            }
            else if (action == "updateActivity")
            {
                txtBoxActivityUpdateDescription.Text = "";
                dtpActivityUpdateStartDate.Value = DateTime.Now;
                dtpActivityUpdateEndDate.Value = DateTime.Now;
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void imgDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities");
            showPanel("ListAllActivities");
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Drinks");
            showPanel("ListAllDrinks");
        }

        private void btnListAllDrinks_Click(object sender, EventArgs e)
        {
            showPanel("ListAllDrinks");
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            showPanel("AddDrink");
        }

        private void btnSubmitAddDrink_Click(object sender, EventArgs e)
        {
            // validate user input before attempting to add the drink
            if (!String.IsNullOrEmpty(txtBoxDrinkName.Text) && Convert.ToDecimal(txtBoxDrinkPrice.Text) > 0 && int.Parse(txtBoxStock.Text) > 0)
            {
                // create new drink object
                Drink newDrink = new Drink();

                // get the drink data from the user and fill the object so we can pass the object to the service
                newDrink.Name = txtBoxDrinkName.Text;
                newDrink.Price = Convert.ToDecimal(txtBoxDrinkPrice.Text);
                newDrink.isAlcoholic = chkBoxDrinkType.Checked;
                newDrink.Stock = int.Parse(txtBoxStock.Text);
                newDrink.Sold = int.Parse(txtBoxAddDrinkSold.Text);

                // try adding the drink
                try
                {
                    DrinkService drinkService = new DrinkService();
                    drinkService.AddDrink(newDrink);

                    // reset all fields
                    resetFields("addDrink");

                    // show success message
                    lblAddDrinkMsg.Text = "Drink added successfully.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred!\n{ex.Message}");
                }
            }

            else
                MessageBox.Show("Please fill in all fields with a valid inputs.");
        }

        private void btnCancelAddDrink_Click(object sender, EventArgs e)
        {
            // if user cancel adding a drink go to the drinks list and reset the fields
            showPanel("ListAllDrinks");
            resetFields("addDrink");
        }

        private void btnUpdateDrink_Click(object sender, EventArgs e)
        {
            if (selectedDrinkFromListView != null)
                showPanel("UpdateDrink");

            else
            {
                showPanel("ListAllDrinks");
                MessageBox.Show("Please select a drink to update it.");
            }
        }

        private void btnUpdateDrinkSubmit_Click(object sender, EventArgs e)
        {
            // get the drink data from the user
            selectedDrinkFromListView.Name = txtBoxUpdateDrinkName.Text;
            selectedDrinkFromListView.Price = Convert.ToDecimal(txtBoxUpdateDrinkPrice.Text);
            selectedDrinkFromListView.isAlcoholic = chkBoxUpdateDrinkType.Checked;
            selectedDrinkFromListView.Stock = int.Parse(txtBoxUpdateDrinkStock.Text);
            selectedDrinkFromListView.Sold = int.Parse(txtBoxUpdateDrinkSold.Text);

            // validate user inputs
            if (!String.IsNullOrEmpty(selectedDrinkFromListView.Name) && selectedDrinkFromListView.Price > 0 && selectedDrinkFromListView.Stock > 0)
            {
                //  try to update the drink
                try
                {
                    DrinkService drinkService = new DrinkService();
                    drinkService.UpdateDrink(selectedDrinkFromListView);

                    // reset all fields
                    resetFields("updateDrink");

                    // show success message
                    lblUpdateDrinkMsg.Text = "Drink updated successfully.";

                    // reset selected drink
                    selectedDrinkFromListView = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            else
                MessageBox.Show("Please fill in all fields with a valid inputs.");
        }

        private void btnUpdateDrinkCancel_Click(object sender, EventArgs e)
        {
            // show drinks panel
            showPanel("ListAllDrinks");

            // reset all fields
            resetFields("updateDrink");
        }

        private void btnDeleteDrink_Click(object sender, EventArgs e)
        {
            if (selectedDrinkFromListView != null)
            {
                // ask user to confirm
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to remove this drink?", "Danger zone!", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        DrinkService drinkService = new DrinkService();
                        drinkService.DeleteDrink(selectedDrinkFromListView.Id);

                        MessageBox.Show("Drink deleted.");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred:\n{ex.Message}");
                    }
                }

            }
            else
                MessageBox.Show("Please select a drink to delete it.");

            // render a fresh list in both cases
            showPanel("ListAllDrinks");
        }

        private void listViewDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDrinkFromListView = new Drink();

            // get the selected drink data from the listview as a collection
            ListView.SelectedListViewItemCollection selectedDrinkCollection = this.listViewDrinks.SelectedItems;

            foreach (ListViewItem item in selectedDrinkCollection)
            {
                selectedDrinkFromListView.Id = int.Parse(item.SubItems[0].Text);
                selectedDrinkFromListView.Name = item.SubItems[1].Text;
                selectedDrinkFromListView.isAlcoholic = item.SubItems[2].Text == "yes" ? true : false;
                selectedDrinkFromListView.Price = Convert.ToDecimal(item.SubItems[3].Text);
                selectedDrinkFromListView.Stock = int.Parse(item.SubItems[4].Text);
                selectedDrinkFromListView.Sold = int.Parse(item.SubItems[6].Text);
            }
        }

        private void DisplaySalesListViews()
        {
            try
            {
                // fill the students listview within the drink panel with a list of drinks
                StudentService studService = new StudentService(); ;
                List<Student> studentList = studService.GetStudents(); ;

                // clear the listview before filling it again
                listViewStudentsS.Clear();
                listViewStudentsS.View = View.Details;
                listViewStudentsS.FullRowSelect = true;
                listViewStudentsS.Columns.Add("Student Id", 75);
                listViewStudentsS.Columns.Add("Student Name", 105);
                listViewStudentsS.Columns.Add("Student Date Of Birth", 105);

                foreach (Student s in studentList)
                {
                    string[] studentArray = { s.Number.ToString(), s.Name, s.BirthDate.ToString("yyyy/MM/dd") };
                    ListViewItem item = new ListViewItem(studentArray);
                    item.Tag = s;
                    listViewStudentsS.Items.Add(item);
                }

                // fill the drinks listview within the drinks panel with a list of drinks
                DrinkService drinkService = new DrinkService(); ;
                List<Drink> drinkList = drinkService.GetDrinks(); ;

                // clear the listview before filling it again
                listViewDrinksS.Clear();
                listViewDrinksS.View = View.Details;
                listViewDrinksS.FullRowSelect = true;
                listViewDrinksS.Columns.Add("Drink Id", 105);
                listViewDrinksS.Columns.Add("Drink Name", 105);
                listViewDrinksS.Columns.Add("Price", 105);
                listViewDrinksS.Columns.Add("Drink Type", 105);
                listViewDrinksS.Columns.Add("Stock", 105);

                foreach (Drink d in drinkList)
                {
                    string alcoholic = d.isAlcoholic ? "alcoholic" : "non-alcoholic";
                    string[] drinkArray = { d.Id.ToString(), d.Name, d.Price.ToString(), alcoholic, d.Stock.ToString() };
                    ListViewItem item = new ListViewItem(drinkArray);
                    item.Tag = d;
                    listViewDrinksS.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the lists: " + e.Message);
            }
        }

        private void listViewStudentsS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewStudentsS.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem selectedItem = listViewStudentsS.SelectedItems[0];
            Student selectedStudent = (Student)selectedItem.Tag;

            lblStudentName.Text = selectedStudent.Name.ToString();
        }

        private void listViewDrinksS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDrinksS.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem selectedItem = listViewDrinksS.SelectedItems[0];
            Drink selectedDrink = (Drink)selectedItem.Tag;

            lblDrinkNameS.Text = selectedDrink.Name.ToString();
            lblDrinkPriceS.Text = selectedDrink.Price.ToString();
        }

        private void checkOutBtn_Click(object sender, EventArgs e)
        {
            Student selectedStudent = (Student)listViewStudentsS.SelectedItems[0].Tag;

            Drink selectedDrink = (Drink)listViewDrinksS.SelectedItems[0].Tag;

            PurchaseService purchaseService = new PurchaseService();
            purchaseService.InsertPurchase(selectedStudent, selectedDrink);
            purchaseService.UpdateStock(selectedDrink);

            DisplaySalesListViews();

            lblStudentName.Text = "";
            lblDrinkNameS.Text = "";
            lblDrinkPriceS.Text = "";

            MessageBox.Show("The purchase has been registered.");
        }

        private void salesPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Sales Point");
        }

        private void revenueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("RevenueReport");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RevenueService purchaseService = new RevenueService();

            string sales = purchaseService.GetNumberOfSales(Convert.ToDateTime(dateTimePickerStartDate.Value), Convert.ToDateTime(dateTimePickerEndDate.Value)).ToString();
            string turnover = purchaseService.GetTurnover(dateTimePickerStartDate.Value, dateTimePickerEndDate.Value).ToString("0.00");
            string customerNumber = purchaseService.GetNumberOfCustomers(Convert.ToDateTime(dateTimePickerStartDate.Value), Convert.ToDateTime(dateTimePickerEndDate.Value)).ToString();
            
            listView3.Clear();

            listView3.View = View.Details;
            listView3.FullRowSelect = true;
            listView3.Columns.Add("Sales", 50);
            listView3.Columns.Add("Turnover", 100);
            listView3.Columns.Add("Customers", 100);

            string[] reportArray = { sales, turnover, customerNumber};
            ListViewItem li = new ListViewItem(reportArray);
            listView3.Items.Add(li);
            
        }

        private void activityParticipantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activity Participants");
        }

        private void lstViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayParticipation();
        }

        private void DisplayParticipation()
        {

            ActivityStudentService activStudService = new ActivityStudentService();
            try
            {

                lstViewParticipants.Items.Clear();
                lstViewNonParticipants.Items.Clear();

                Activity activ = (Activity)lstViewActivities.SelectedItems[0].Tag;
                List<Student> studentParticipants = activStudService.GetParticipants((Activity)lstViewActivities.SelectedItems[0].Tag);
                List<Student> studentNonParticipants = activStudService.GetNonParticipants((Activity)lstViewActivities.SelectedItems[0].Tag);

                foreach (Student st in studentParticipants)
                {
                    string[] stArray = { st.Number.ToString(), st.Name, };
                    ListViewItem item = new ListViewItem(stArray);
                    item.Tag = st;
                    lstViewParticipants.Items.Add(item);
                }

                foreach (Student st in studentNonParticipants)
                {
                    string[] stArray = { st.Number.ToString(), st.Name, };
                    ListViewItem item = new ListViewItem(stArray);
                    item.Tag = st;
                    lstViewNonParticipants.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnRemoveParticipant_Click(object sender, EventArgs e)
        {
            if (lstViewParticipants.SelectedItems[0].Tag != null)
            {
                // remove participant from the respective activity in the ActivityStudents database table 
                ActivityStudentService participantService = new ActivityStudentService();
                participantService.RemoveParticipant((Student)lstViewParticipants.SelectedItems[0].Tag, (Activity)lstViewActivities.SelectedItems[0].Tag);

                MessageBox.Show("Removed a person from participants.");

            }
            else
            {
                MessageBox.Show("Please select a participant to remove.");
            }

            DisplayParticipation();
        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            if (lstViewNonParticipants.SelectedItems[0].Tag != null)
            {
                // add participant to the respective activity in the ActivityStudents database table 
                ActivityStudentService participantService = new ActivityStudentService();
                participantService.AddParticipant((Student)lstViewNonParticipants.SelectedItems[0].Tag, (Activity)lstViewActivities.SelectedItems[0].Tag);

                MessageBox.Show("Added a new participant.");

            }
            else
            {
                MessageBox.Show("Please select a participant to add.");
            }

            DisplayParticipation();
            //showPanel("Activity Participants");
        }

        private void btnActivityListAll_Click(object sender, EventArgs e)
        {
            showPanel("ListAllActivities");
        }

        private void btnActivityAdd_Click(object sender, EventArgs e)
        {
            showPanel("AddActivity");
        }

        private void btnActivityAddSubmit_Click(object sender, EventArgs e)
        {
            ActivityService activityService = new ActivityService();

            // show message if description is invalid
            if (String.IsNullOrEmpty(txtBoxActivityAddDescription.Text))
                MessageBox.Show("Please provide a description for the activity!");

            // show message if startdate or end date is invalid
            else if (!activityService.IsValidActivityDate(dtpActivityAddStartDate.Value, dtpActivityAddEndDate.Value))
                MessageBox.Show("Invalid date!");

            else
            {
                try
                {
                    // try to add new activity
                    Activity activity = new Activity
                    {
                        Description = txtBoxActivityAddDescription.Text,
                        StartDateTime = dtpActivityAddStartDate.Value,
                        EndDateTime = dtpActivityAddEndDate.Value
                    };

                    activityService.AddActivity(activity);

                    // reset fields
                    resetFields("addActivity");

                    // show success message
                    lblActivityAddMsg.Text = "New activity has been added.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void btnActivityAddCancel_Click(object sender, EventArgs e)
        {
            showPanel("ListAllActivities");
        }

        private void btnActivityUpdateSubmit_Click(object sender, EventArgs e)
        {
            // get the drink data from the user
            selectedActivityFromListView.Description = txtBoxActivityUpdateDescription.Text;
            selectedActivityFromListView.StartDateTime = Convert.ToDateTime(dtpActivityUpdateStartDate.Value);
            selectedActivityFromListView.EndDateTime = Convert.ToDateTime(dtpActivityUpdateEndDate.Value);

            ActivityService activityService = new ActivityService();

            // show message if description or date is invalid
            if (String.IsNullOrEmpty(txtBoxActivityUpdateDescription.Text))
                MessageBox.Show("Please provide a description for the activity!");

            else if (!activityService.IsValidActivityDate(dtpActivityUpdateStartDate.Value, dtpActivityUpdateEndDate.Value))
                MessageBox.Show("Invalid date!");

            else
            {
                try
                {
                    // try to update the activity
                    activityService.UpdateActivity(selectedActivityFromListView);

                    // reset fields
                    resetFields("updateActivity");

                    // show success message
                    MessageBox.Show("Activity has been updated.");

                    // go to activity list
                    showPanel("ListAllActivities");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void listViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedActivityFromListView = new Activity();

            ListView.SelectedListViewItemCollection selectedActivityCollection = this.listViewActivities.SelectedItems;

            foreach (ListViewItem item in selectedActivityCollection)
            {
                selectedActivityFromListView.Id = int.Parse(item.SubItems[0].Text);
                selectedActivityFromListView.Description = item.SubItems[1].Text;
                selectedActivityFromListView.StartDateTime = Convert.ToDateTime(item.SubItems[2].Text);
                selectedActivityFromListView.EndDateTime = Convert.ToDateTime(item.SubItems[3].Text);
            }
        }

        private void btnActivityUpdate_Click(object sender, EventArgs e)
        {
            if (selectedActivityFromListView != null)
                showPanel("UpdateActivity");

            else
            {
                showPanel("ListAllActivities");
                MessageBox.Show("Please select an activity to update it.");
            }
        }

        private void btnActivityUpdateCancel_Click(object sender, EventArgs e)
        {
            showPanel("ListAllActivities");
        }

        private void btnActivityDelete_Click(object sender, EventArgs e)
        {
            if (selectedActivityFromListView != null)
            {
                // ask user to confirm
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to remove this activity?", "Danger zone!", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        // try to delete activity
                        ActivityService activityService = new ActivityService();
                        activityService.DeleteActivity(selectedActivityFromListView.Id);

                        MessageBox.Show("Activity deleted.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred:\n{ex.Message}");
                    }
                }

            }
            else
                MessageBox.Show("Please select an activity to delete it.");

            // render a fresh list in both cases
            showPanel("ListAllActivities");
        }

        private void supervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Supervisors");
        }

        private void supervisorsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Supervisors");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillListViewSupervisorNonSupervisor();
        }
        public void fillListViewSupervisorNonSupervisor()
        {
            int id = 0;
            foreach (ListViewItem l in this.listView1.SelectedItems)
            {
                id = int.Parse(l.SubItems[0].Text);
            }

            SupervisorActivityService supervisorActivityService = new SupervisorActivityService();
            List<Teacher> supervisorList = supervisorActivityService.GetAllActivitySupervisors(id);
            List<Teacher> nonSupervisorList = supervisorActivityService.GetAllNonSupervisors();
            List<int> supervisors = new List<int>();

            // clear the listview before filling it again
            listView2.Clear();

            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.Columns.Add("Lecturer ID", 100);
            listView2.Columns.Add("Lecturer Name", 200);

            foreach (Teacher t in supervisorList)
            {
                string[] teacherArray = { t.Number.ToString(), t.Name };
                ListViewItem li = new ListViewItem(teacherArray);
                listView2.Items.Add(li);
                supervisors.Add(t.Number);
            }

            listViewNonSupervisors.Clear();

            listViewNonSupervisors.View = View.Details;
            listViewNonSupervisors.FullRowSelect = true;
            listViewNonSupervisors.Columns.Add("Lecturer ID", 100);
            listViewNonSupervisors.Columns.Add("Lecturer Name", 200);

            foreach (Teacher t in nonSupervisorList)
            {
                if (!(supervisors.Contains(t.Number)))
                {
                    string[] teacherArray = { t.Number.ToString(), t.Name };
                    ListViewItem li = new ListViewItem(teacherArray);
                    listViewNonSupervisors.Items.Add(li);
                }
            }
        }

        private void SupervisorDeleteButton_Click(object sender, EventArgs e)
        {
            //checks if the right kind of teacher is selected
            if (listViewNonSupervisors.SelectedItems.Count == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this supervisor?", "Delete Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int selectedTeacher = 1;
                    foreach (ListViewItem l in listView2.SelectedItems)
                    {
                        selectedTeacher = int.Parse(l.SubItems[0].Text);
                    }

                    int selectedActivity = 1;
                    foreach (ListViewItem l in listView1.SelectedItems)
                    {
                        selectedActivity = int.Parse(l.SubItems[0].Text);
                    }

                    SupervisorActivityService supervisorActivityService = new SupervisorActivityService();
                    supervisorActivityService.DeleteSupervisor(selectedTeacher, selectedActivity);

                    fillListViewSupervisorNonSupervisor();
                    MessageBox.Show("Supervisor Deleted");
                }
            }
            else
            {
                MessageBox.Show("Please select an activity supervisor!");
            }
        }

        private void SupervisorAddButton_Click(object sender, EventArgs e)
        {
            int selectedTeacher = 0;
            foreach (ListViewItem l in listViewNonSupervisors.SelectedItems)
            {
                selectedTeacher = int.Parse(l.SubItems[0].Text);
            }

            int selectedActivity = 0;
            foreach (ListViewItem l in listView1.SelectedItems)
            {
                selectedActivity = int.Parse(l.SubItems[0].Text);
            }

            SupervisorActivityService supervisorActivityService = new SupervisorActivityService();
            try
            {
                supervisorActivityService.AddSupervisor(selectedTeacher, selectedActivity);
            }
            catch
            {
                MessageBox.Show("Please select a teacher who isn't already supervising.");
            }

            fillListViewSupervisorNonSupervisor();
        }

        private void forgotPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForgotPasswordWindow forgotPassword = new ForgotPasswordWindow();
            forgotPassword.TopLevel = true;
            forgotPassword.ShowDialog();
        }

    }
}

