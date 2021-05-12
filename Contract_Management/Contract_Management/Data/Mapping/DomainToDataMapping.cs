using Contract_Management.Data;
using Contract_Management.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Contract_Management.Data.Mapping
{
    public static class DomainToDataMapping
    {
        public static Employee_Doc ConvertAsDataEntity(this DocumentUploadModel obj)
        {
            return new Employee_Doc
            {
                TRANS_ID = obj.TRANS_ID,
                VENDOR_CODE = obj.VENDOR_CODE,
                PO_NUMBER = obj.PO_NUMBER,
                EMPLOYEE_ID = obj.EMPLOYEE_ID,
                DOC_ID = obj.DOC_ID,
                DOC_EXTN = obj.DOC_EXTN,
                DOCUMENT = obj.DOCUMENT,
                CREATED_BY = obj.CREATED_BY,
                CREATED_DATE = obj.CREATED_DATE,



            };
        }
        public static Vendor_Doc ConvertAsDataEntity(this DocumentUploadModel obj, string type)      //ONLY FOR CREATING METHOD WITH DIFFERENT PARAMETERS
        {
            return new Vendor_Doc
            {
                TRANS_ID = obj.TRANS_ID,
                VENDOR_CODE = obj.VENDOR_CODE,
                PO_NUMBER = obj.PO_NUMBER,
                DOC_ID = obj.DOC_ID,
                DOC_EXTN = obj.DOC_EXTN,
                DOCUMENT = obj.DOCUMENT,
                CREATED_BY = obj.CREATED_BY,
                CREATED_DATE = obj.CREATED_DATE,



            };
        }

        public static Job ConvertAsDataEntity(this JobsViewModel obj)
        {
            return new Job
            {
                JOB_ID = obj.JOB_ID,
                PO_NUM = obj.PO_NUM,
                ARC = obj.ARC,
                ARC_NO = obj.ARC_NO,
                JOB_NAME = obj.JOB_NAME,
                DEPT_ID = obj.DEPT_ID,
                AREA = obj.AREA,
                CONT_ID = obj.CONT_ID,
                ADDRESS = obj.ADDRESS,
                HOUSE_KEEPING = obj.HOUSE_KEEPING,
                ONLY_EXCEMPTION = obj.ONLY_EXCEMPTION,
                NO_WORKERS = obj.NO_WORKERS,
                TOTAL_WORKERS = obj.TOTAL_WORKERS,
                TOTAL_PASS_COUNT = obj.TOTAL_PASS_COUNT,
                ISMW_WORKERS_ASSIGNED = obj.ISMW_WORKERS_ASSIGNED,
                ISMW_PASS_COUNT = obj.ISMW_PASS_COUNT,
                COMPLETED_DATE = obj.COMPLETED_DATE,
                WORKERS_LICENSE_PASS = obj.WORKERS_LICENSE_PASS,
                WL_PASS_FROM = obj.WL_PASS_FROM,
                WL_PASS_TO = obj.WL_PASS_TO,
                STAFF_PASS = obj.STAFF_PASS,
                ISWL_LICENSE_CLOSED = obj.ISWL_LICENSE_CLOSED,
                ISMW = obj.ISMW,
                ISMW_LICENSE_PASS = obj.ISMW_LICENSE_PASS,
                ISMW_FROM = obj.ISMW_FROM,
                ISMW_TO = obj.ISMW_TO,
                BLOCK = obj.BLOCK,
                BLOCK_REMARKS = obj.BLOCK_REMARKS,
                CREATED_BY = obj.CREATED_BY,
                CREATED_ON = obj.CREATED_ON,
                DELETED_BY = obj.DELETED_BY,
                DELETED_ON = obj.DELETED_ON,
                SEC_REMARKS = obj.SEC_REMARKS
            };
        }

        public static Employee ConvertAsDataEntity(this EmployeesViewModel obj)
        {
            return new Employee
            {
                EMP_ID = obj.EMP_ID,
                PO_NUM = obj.PO_NUM,
                EMP_NAME = obj.EMP_NAME,
                GENDER = obj.GENDER,
                MARITAL_STATUS = obj.MARITAL_STATUS,
                EMP_ESINO = obj.EMP_ESINO,
                ESI_REGN_DATE = obj.ESI_REGN_DATE,
                PEHCHAN = obj.PEHCHAN,
                EMP_PF_NO = obj.EMP_PF_NO,
                PF_REGN_DATE = obj.PF_REGN_DATE,
                UAN = obj.UAN,
                EPS = obj.EPS,
                EVICTEE = obj.EVICTEE,
                EVICTEE_CARD_NO = obj.EVICTEE_CARD_NO,
                ISMW = obj.ISMW,
                DISABILITY_TYPE = obj.DISABILITY_TYPE,
                NOMINEE_RELATIONSHIP_TYPE = obj.RELATION_IP,
                NOMINEE_RELATION_NAME = obj.RELATION_NAME,
                DOB = Convert.ToDateTime(obj.DOB),
                DOJ = Convert.ToDateTime(obj.DOJ),
                PRESENT_ADRS = obj.PRESENT_ADRS,
                PERMANENT_ADRS = obj.PERMANENT_ADRS,
                CITY = obj.CITY,
                STATE = obj.STATE,
                PINCODE = obj.PINCODE,
                MOBILE_NO = obj.ICE_PHONE,
                EMP_TYPE = obj.EMP_TYPE,
                ID_TYPE = obj.ID_TYPE,
                AADHAR_NO = obj.ID_NUM,
                PHOTO = obj.PHOTO,
                BANK_NAME = obj.BANK_NAME,
                BANK_BRANCH = obj.BANK_BRANCH,
                BANK_ADDRESS = obj.BANK_ADDRESS,
                BANK_ACNO = obj.BANK_ACNO,
                BLACK_LISTED = obj.BLACK_LISTED,
                BLACK_LISTED_REASON = obj.BLACK_LISTED_REASON,
                BLACK_LISTED_DATE = obj.BLACK_LISTED_DATE,
                REMARKS = obj.REMARKS,
                CREATED_ON = obj.CREATED_ON,
                DELETED_BY = obj.DELETED_BY,
                DELETED_ON = obj.DELETED_ON

            };
        }




        //public static Job_Arc ConvertAsDataEntity(this JobsViewModel obj1)
        //{
        //    return new Job_Arc
        //    {
        //        ARC_ID = obj.ARC_ID,
        //        ARC_NO = obj.ARC_NO,
        //        PO_NUM = obj.PO_NUM,
        //        DESCRIPTION = obj.DESCRIPTION,
        //        ARC_DATE = obj.ARC_DATE,
        //        SCHEDULE_FROM = obj.SCHEDULE_FROM,
        //        SCHEDULE_TO = obj.SCHEDULE_TO,
        //        DEACTIVATED_ON = obj.DEACTIVATED_ON,
        //        CREATED_BY = obj.CREATED_BY,
        //        CREATED_ON = obj.CREATED_ON

        //    };
        //}


        #region Multiple Objects
        //public static IEnumerable<Nakshathras> ConvertAsDomainEntity(this IEnumerable<Nakshathra> entityCollection)
        //{
        //    if (entityCollection != null)
        //    {
        //        return entityCollection.Select(obj => new Nakshathras()
        //        {
        //            Id = obj.Id,
        //            Name = obj.Name,
        //            Name_ML = obj.Name_ML,
        //            Order = obj.Order,
        //            Status = obj.Status

        //        });
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        #endregion
    }
}