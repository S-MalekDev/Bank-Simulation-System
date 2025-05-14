using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANK_DataAccessLayer;

namespace BANK_BusinessLayer
{
    public class clsBankingJobs
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _JobID;

        public int JobID { get { return _JobID; } }
        public string JobTitle { get; set; }
        public string SalaryRange { get; set; }


        public clsBankingJobs()
        {
            _JobID = -1;
            JobTitle = string.Empty;
            SalaryRange = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsBankingJobs(int JobID, string JobTitle, string SalaryRange)
        {
            _JobID = JobID;
            this.JobTitle = JobTitle;
            this.SalaryRange = SalaryRange;

            _Mode = enMode.Update;
        }

        static public DataTable GetAllBankingJobs()
        {
            return clsBankingJobsData.GetAllBankingJobs();
        }

        static public clsBankingJobs Find(int JobID)
        {

            string JobTitle = string.Empty;
            string SalaryRange = string.Empty;


            if (clsBankingJobsData.GetBankingJobInfoByID(JobID, ref JobTitle, ref SalaryRange))
            {
                return new clsBankingJobs(JobID, JobTitle, SalaryRange);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNewBankingJob()
        {
            _JobID = clsBankingJobsData.AddNewBankingJob(this.JobTitle, this.SalaryRange);

            return _JobID != -1;
        }

        private bool _UpdateBankingJob()
        {
            return clsBankingJobsData.UpdateBankingJob(this.JobID, this.JobTitle, this.SalaryRange);
        }

        static public bool DeleteBankingJob(int JobID)
        {
            return clsBankingJobsData.DeleteBankingJob(JobID);
        }

        static public bool IsBankingJobExist(int JobID)
        {
            return clsBankingJobsData.IsBankingJobExist(JobID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewBankingJob())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                case enMode.Update:
                    {
                        return _UpdateBankingJob();

                    }
                default:
                    {
                        return false;
                    }
            }

        }
    }



}
