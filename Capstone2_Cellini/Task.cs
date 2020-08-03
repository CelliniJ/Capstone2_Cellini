using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone2_Cellini
{
    class Task
    {
        #region fields
        private int tasknumber;
        private string tmname;
        private string taskdesc;
        private string duedate;
        private bool taskcomplete;
        #endregion

        #region properties
        public int TaskNumber
        {
            get { return tasknumber; }
            set { tasknumber = value; }
        }
        public string TMName
        {
            get { return tmname; }
            set { tmname = value; }
        }
        public string TaskDesc
        {
            get { return taskdesc; }
            set { taskdesc = value; }
        }
        public string DueDate
        {
            get { return duedate; }
            set { duedate = value; }
        }
        public bool TaskComplete
        {
            get { return taskcomplete; }
            set { taskcomplete = value; }
        }
        #endregion

        #region Constructors
        public Task() { }

        public Task(int TaskNumber, string TMName, string TaskDesc, string DueDate, bool TaskComplete)
        {
            tasknumber = TaskNumber;
            tmname = TMName;
            taskdesc = TaskDesc;
            duedate = DueDate;
            taskcomplete = false;
            #endregion
        }
    }
}
