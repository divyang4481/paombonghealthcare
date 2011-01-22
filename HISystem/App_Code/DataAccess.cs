﻿
/* ACKNOWLEDGMENTS 2011
 * 
 * INSPIRED BY CHRIZZI.. - SuperDevLester
 * Gerald Magno inspired by his greatness
 *
 * TECHNICAL ADVISER
 * 1. Elcid Serrano
 * 
 * TEAM LEAD
 * 1. Gerald Aldana Magno
 * 
 * FRONT END DEVELOPER
 * 1. Gerald Aldana Magno
 * 
 * BACK END DEVELOPERS
 * 1. Gerald Aldana Magno
 * 2. Lakhi Lester T. Calantoc
 * 
 * BUSINESS ANALYST/SOFTWARE QUALITY ASSURANCE
 * 1. Kendrick Bacani
 * 2. Lakhi Lester T. Calantoc
 * 3. Gerald Aldana Magno
 * 
 */

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

#region Logs

/* Log Positive
 *      1. Add Patient Finished - Lakhi 10/5/2010
 *      2. Update Patient Finished - Lakhi 10/5/2010
 *      3. Get Values Finished - Lakhi 10/5/2010
 *      4. Add Medicine Finished - Lakhi 10/10/2010
 *      5. Get Medicine Finished - Lakhi 10/10/2010
 *      6. Delete Medicine Finished - Lakhi 10/10/2010
 *      7. Grid View Finished - Lakhi 10/10/2010
 *      8. BarangayId Fixed Finished - Lakhi 10/10/2010
 *      9. Search By Medicine Name Fixed and Finished - Lakhi 10/12/2010
 *      10.Add to List Finished - Lakhi 10/12/2010
 *      11.Update Medicine Finished - Lakhi 10/13/2010
 *      12.Sorting Medicine Inventory Finished - Lakhi 10/13/2010
 *      13.Inventory Module Finished - Lakhi 10/13/2010
 *      14.Added Report Template and Manage Report Module Finished - Lakhi 10/20/2010
 *      15.Updated Database Tables also fields Finished - Lakhi 10/20/2010
 * 
 * 
 * 
 */

/* Log Negative
 *      1. BarangayId Not yet Fixed in Update and Get Values - Lakhi 10/5/2010  CHECK 
 *      2. Inventory Not yet Finished - Lakhi 10/10/2010                        CHECK
 *      3. Search By Medicine Name Not yet Finished - Lakhi 10/12/2010          CHECK
 *      4. Medical Record Not Yet Finished - Lakhi 10/20/2010
 *      5. POP UP window for PatientSearch for Modules Patient Demographics and 
 *          Medical Records Not yet Finished - Lakhi 10/20/2010
 * 
 * 
 * 
 */

#endregion

public class DataAccess
{
    private string dataconnection =
   // @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\paombongdb.mdf;Integrated Security=True;User Instance=True;Initial Catalog=paombongdb";
    @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Gerald\Desktop\cap\App_Data\paombongdb.mdf;Integrated Security=True;User Instance=True";

    private MonthConverter mc;

    public string Dataconnection
    {
        get { return dataconnection; }
        set { dataconnection = value; }
    }
   
    public DataAccess()
    {

    }

    /*Add Patient Finished - Lakhi 10/5/2010*/

    public bool AddPatient(string PatientFirstName, string PatientMiddleName, string PatientLastName,
        string PatientContactNumber, string PatientEmailAddress, string PatientSuffix, string PatientBirthdate, string PatientBirthplace, string PatientAddress,
        string PatientFaxNumber, string PatientDoctor, string PatientNationality, string PatientCity,
        string PatientSex, string PatientMaritalStatus, string PatientSpouseName, string PatientCompany, string DateRegistered, string PatientBarangay)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

            connPatient.Open();
            SqlCommand cmdTxt = new SqlCommand("AddPatient", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@PatientFirstName", SqlDbType.Char).Value = PatientFirstName;
            cmdTxt.Parameters.Add("@PatientMiddleName", SqlDbType.Char).Value = PatientMiddleName;
            cmdTxt.Parameters.Add("@PatientLastName", SqlDbType.Char).Value = PatientLastName;
            cmdTxt.Parameters.Add("@PatientContactNumber", SqlDbType.Char).Value = PatientContactNumber;
            cmdTxt.Parameters.Add("@PatientEmailAddress", SqlDbType.Char).Value = PatientEmailAddress;
            cmdTxt.Parameters.Add("@PatientNationality", SqlDbType.Char).Value = PatientNationality;
            cmdTxt.Parameters.Add("@PatientCity", SqlDbType.Char).Value = PatientCity;
            cmdTxt.Parameters.Add("@PatientBirthdate", SqlDbType.Char).Value = PatientBirthdate;
            cmdTxt.Parameters.Add("@PatientBirthPlace", SqlDbType.Char).Value = PatientBirthplace;
            cmdTxt.Parameters.Add("@PatientAddress", SqlDbType.Char).Value = PatientAddress;
            cmdTxt.Parameters.Add("@PatientFaxNumber", SqlDbType.Char).Value = PatientFaxNumber;
            cmdTxt.Parameters.Add("@PatientDoctor", SqlDbType.Char).Value = PatientDoctor;
            cmdTxt.Parameters.Add("@PatientSex", SqlDbType.Char).Value = PatientSex;
            cmdTxt.Parameters.Add("@PatientCompany", SqlDbType.Char).Value = PatientCompany;
            cmdTxt.Parameters.Add("@PatientMaritalStatus", SqlDbType.Char).Value = PatientMaritalStatus;
            cmdTxt.Parameters.Add("@PatientSpouseName", SqlDbType.Char).Value = PatientSpouseName;
            cmdTxt.Parameters.Add("@DateRegistered", SqlDbType.Char).Value = DateRegistered;
            cmdTxt.Parameters.Add("@PatientSuffix", SqlDbType.Char).Value = PatientSuffix;
            cmdTxt.Parameters.Add("@PatientBarangay", SqlDbType.Char).Value = PatientBarangay;
            cmdTxt.Parameters.Add("@DateYear", SqlDbType.Char).Value = DateTime.Now.Year.ToString();

            int checker = cmdTxt.ExecuteNonQuery();
            if (checker > 0)
                return true;
            else
                return false;
    }

    public DataTable GetValues(string Patient_Id)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        SqlDataReader dtrPatient;
        DataTable patientData = new DataTable();
        patientData.Columns.Add("PatientID");
        patientData.Columns.Add("PatientLName");
        patientData.Columns.Add("PatientFName");
        patientData.Columns.Add("PatientMName");
        patientData.Columns.Add("PatientSuffix");
        patientData.Columns.Add("PatientSex");
        patientData.Columns.Add("PatientCompany");
        patientData.Columns.Add("PatientCity");
        patientData.Columns.Add("PatientBirthdate");
        patientData.Columns.Add("PatientBirthplace");
        patientData.Columns.Add("PatientCivilStatus");
        patientData.Columns.Add("SpouseName");
        patientData.Columns.Add("PatientNationality");
        patientData.Columns.Add("PatientAddress");
        patientData.Columns.Add("PatientContactNumber");
        patientData.Columns.Add("PatientEmailAddress");
        patientData.Columns.Add("PatientFaxNumber");
        patientData.Columns.Add("PatientDoctor");
        patientData.Columns.Add("DateRegistered");
        patientData.Columns.Add("PatientBarangay");

        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("GetPatientData", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@Patient_Id", SqlDbType.Char).Value = Patient_Id;
            dtrPatient = cmdTxt.ExecuteReader();
            dtrPatient.Read();

            patientData.Rows.Add(dtrPatient["PatientID"].ToString(),
                dtrPatient["PtLname"].ToString().Trim(), dtrPatient["PtFname"].ToString().Trim(),
                dtrPatient["PtMname"].ToString().Trim(), dtrPatient["PtSuffix"].ToString().Trim(),
                dtrPatient["PtGender"].ToString().Trim(),
                dtrPatient["PtCompany"].ToString().Trim(),
                dtrPatient["PtBusinessCty"].ToString().Trim(),
                dtrPatient["PtBdate"].ToString().Trim(),
                dtrPatient["PtBplace"].ToString().Trim(),
                dtrPatient["CivilStatus"].ToString().Trim(),
                dtrPatient["SpouseName"].ToString().Trim(),
                dtrPatient["Nationality"].ToString().Trim(),
                dtrPatient["PtAddress"].ToString().Trim(),
                dtrPatient["PtContact"].ToString().Trim(),
                dtrPatient["PtEmail"].ToString().Trim(),
                dtrPatient["PtFaxNumber"].ToString().Trim(),
                dtrPatient["PtDoctor"].ToString().Trim(),
                dtrPatient["DateRegistered"].ToString().Trim(),
                dtrPatient["BarangayName"].ToString().Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show("No Patient Found for Patient ID: " + Patient_Id);
        }
        finally
        {
            connPatient.Close();
        }
        return patientData;
    }



    public DataTable GetValuesConsultation(string Patient_Id)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        SqlDataReader dtrPatient;
        DataTable patientData = new DataTable();
        patientData.Columns.Add("PatientID");
        patientData.Columns.Add("PatientLName");
        patientData.Columns.Add("PatientFName");
        patientData.Columns.Add("PatientMName");        
        patientData.Columns.Add("PatientBirthdate");        
        patientData.Columns.Add("PatientAddress");
        patientData.Columns.Add("PatientFaxNumber");
        patientData.Columns.Add("PatientBarangay");

        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("GetPatientData2", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@Patient_Id", SqlDbType.Char).Value = Patient_Id;
            dtrPatient = cmdTxt.ExecuteReader();
            dtrPatient.Read();

            patientData.Rows.Add(dtrPatient["PatientID"].ToString(),
                dtrPatient["PtLname"].ToString().Trim(), 
                dtrPatient["PtFname"].ToString().Trim(),
                dtrPatient["PtMname"].ToString().Trim(), 
                dtrPatient["PtBdate"].ToString().Trim(),
               
                dtrPatient["PtAddress"].ToString().Trim(),
                
                dtrPatient["PtFaxNumber"].ToString().Trim(),               
                dtrPatient["BarangayName"].ToString().Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
        return patientData;
    }




    /*Update Record Finished - Lakhi 10/5/2010*/

    public void UpdateRecord(string Patient_Id, string PatientFirstName, string PatientMiddleName, string PatientLastName,
        string PatientContactNumber, string PatientEmailAddress, string PatientSuffix, string PatientBirthdate, string PatientBirthplace, string PatientAddress,
        string PatientFaxNumber, string PatientDoctor, string PatientNationality, string PatientCity,
        string PatientSex, string PatientMaritalStatus, string PatientSpouseName, string PatientCompany, string DateRegistered, string PatientBarangay)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("UpdatePatient", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@Patient_Id", SqlDbType.Int).Value = Patient_Id;
            cmdTxt.Parameters.Add("@PatientFirstName", SqlDbType.Char).Value = PatientFirstName;
            cmdTxt.Parameters.Add("@PatientMiddleName", SqlDbType.Char).Value = PatientMiddleName;
            cmdTxt.Parameters.Add("@PatientLastName", SqlDbType.Char).Value = PatientLastName;
            cmdTxt.Parameters.Add("@PatientContactNumber", SqlDbType.Char).Value = PatientContactNumber;
            cmdTxt.Parameters.Add("@PatientEmailAddress", SqlDbType.Char).Value = PatientEmailAddress;
            cmdTxt.Parameters.Add("@PatientNationality", SqlDbType.Char).Value = PatientNationality;
            cmdTxt.Parameters.Add("@PatientCity", SqlDbType.Char).Value = PatientCity;
            cmdTxt.Parameters.Add("@PatientBirthdate", SqlDbType.Char).Value = PatientBirthdate;
            cmdTxt.Parameters.Add("@PatientBirthPlace", SqlDbType.Char).Value = PatientBirthplace;
            cmdTxt.Parameters.Add("@PatientAddress", SqlDbType.Char).Value = PatientAddress;
            cmdTxt.Parameters.Add("@PatientFaxNumber", SqlDbType.Char).Value = PatientFaxNumber;
            cmdTxt.Parameters.Add("@PatientDoctor", SqlDbType.Char).Value = PatientDoctor;
            cmdTxt.Parameters.Add("@PatientSex", SqlDbType.Char).Value = PatientSex;
            cmdTxt.Parameters.Add("@PatientCompany", SqlDbType.Char).Value = PatientCompany;
            cmdTxt.Parameters.Add("@PatientMaritalStatus", SqlDbType.Char).Value = PatientMaritalStatus;
            cmdTxt.Parameters.Add("@PatientSpouseName", SqlDbType.Char).Value = PatientSpouseName;
            cmdTxt.Parameters.Add("@DateRegistered", SqlDbType.Char).Value = DateRegistered;
            cmdTxt.Parameters.Add("@PatientSuffix", SqlDbType.Char).Value = PatientSuffix;
            cmdTxt.Parameters.Add("@PatientBarangay", SqlDbType.Char).Value = PatientBarangay;
            int check = cmdTxt.ExecuteNonQuery();
        //    if (check > 0)
        //        MessageBox.Show("Updated Patient Information Successfully!");
        //    else
        //        MessageBox.Show("Unsuccesfull!! Updating Patient Information Please Try Again!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    public int GetMedicineId(string MedicineName)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId FROM Medicine WHERE MedicineName = @aa", connPatient);
        cmdTxt.Parameters.Add("@aa", SqlDbType.Char).Value = MedicineName;
        SqlDataReader id = cmdTxt.ExecuteReader();
        id.Read();
        int retId = id.GetInt32(0);
        id.Close();
        connPatient.Close();
        return retId;
    }

    /*AddMedicine Finished - Lakhi 10/10/2010*/

    public void AddMedicine(string MedicineName, string CategoryName, int Quantity)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        try
        {
            connPatient.Open();
            SqlCommand cmdTxt = new SqlCommand("AddMedicine", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@MedicineName", SqlDbType.Char).Value = MedicineName;
            cmdTxt.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
            cmdTxt.Parameters.Add("@CategoryName", SqlDbType.Char).Value = CategoryName;
            int checker = cmdTxt.ExecuteNonQuery();
            if (checker > 0)
                MessageBox.Show("<script>window.alert('Add Medicine.')</script>");
            else
                MessageBox.Show("Please Try Again!!");

        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    /*GetMedicine Finished - Lakhi 10/10/2010*/

    public DataTable GetMedicine(string MedicineId)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        SqlDataReader dtrMedicine;
        DataTable medicineData = new DataTable();
        medicineData.Columns.Add("MedicineName");
        medicineData.Columns.Add("Quantity");
        medicineData.Columns.Add("CategoryName");

        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("GetMedicineData", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@MedicineId", SqlDbType.Char).Value = MedicineId;
            dtrMedicine = cmdTxt.ExecuteReader();
            dtrMedicine.Read();

            medicineData.Rows.Add(dtrMedicine["MedicineName"].ToString().Trim()
                ,dtrMedicine["Quantity"].ToString().Trim()
                ,dtrMedicine["CategoryName"].ToString().Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
        return medicineData;
    }

    public void DeleteMedicine(string MedicineId)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
   
        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("Delete From Medicine Where MedicineId = @aa", connPatient);
            cmdTxt.Parameters.Add("@aa", SqlDbType.Int).Value = MedicineId;
            int check = cmdTxt.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    public void RefreshGridviewMedicine(GridView gridView)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Medicine",connPatient);
            DataSet ds = new DataSet();
            da.Fill(ds,"Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    public void RefreshGridviewMedicineByCategory(GridView gridView,string CategoryName)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        try
        {

            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine "+
                "WHERE CategoryId = (SELECT CategoryId FROM Category WHERE CategoryName = @aa)", connPatient);
            cmdTxt.Parameters.Add("@aa",SqlDbType.VarChar).Value = CategoryName;
            SqlDataAdapter da = new SqlDataAdapter(cmdTxt);
            gridView.DataSource = null;
            gridView.DataBind();

            DataSet ds = new DataSet();
            da.Fill(ds, "Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }


  






    public void RefreshGridviewMedicineByName(GridView gridView, string MedicineName)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        SqlDataAdapter da;

        connPatient.Open();
        try
        {
            if (MedicineName != "" || MedicineName != null)
            {
                SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine WHERE MedicineName Like '" +MedicineName.Trim()+"%'", connPatient);
                
                da = new SqlDataAdapter(cmdTxt);
            }
            else
            {
                SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine", connPatient);
                da = new SqlDataAdapter(cmdTxt);
            }
            
            gridView.DataSource = null;
            gridView.DataBind();

            DataSet ds = new DataSet();
            da.Fill(ds, "Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }

    public void RefreshGridviewByQuantityLow(GridView gridView)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        try
        {

            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine " +
                "WHERE Quantity <= 25", connPatient);
            SqlDataAdapter da = new SqlDataAdapter(cmdTxt);
            gridView.DataSource = null;
            gridView.DataBind();

            DataSet ds = new DataSet();
            da.Fill(ds, "Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }
    public void RefreshGridviewByQuantityLowConfig(GridView gridView,int Quantity)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        try
        {

            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine " +
                "WHERE Quantity <= @aa", connPatient);
            cmdTxt.Parameters.Add("@aa", SqlDbType.Int).Value = Quantity;
            SqlDataAdapter da = new SqlDataAdapter(cmdTxt);
            gridView.DataSource = null;
            gridView.DataBind();

            DataSet ds = new DataSet();
            da.Fill(ds, "Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }

    public void RefreshGridviewByCategoryAndQuantityLow(GridView gridView, string CategoryName, int Quantity)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        try
        {

            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine " +
                "WHERE CategoryId = (SELECT CategoryId FROM Category WHERE CategoryName = @aa) AND Quantity <= @ab", connPatient);
            cmdTxt.Parameters.Add("@aa", SqlDbType.VarChar).Value = CategoryName;
            cmdTxt.Parameters.Add("@ab", SqlDbType.Int).Value = Quantity;
            SqlDataAdapter da = new SqlDataAdapter(cmdTxt);
            gridView.DataSource = null;
            gridView.DataBind();

            DataSet ds = new DataSet();
            da.Fill(ds, "Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }


    public void UpdateStock(int MedicineId,int Quantity)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("SELECT Quantity FROM Medicine " +
                "WHERE MedicineId = @aa", connPatient);
            cmdTxt.Parameters.Add("@aa", SqlDbType.Int).Value = MedicineId;
            SqlDataReader dr = cmdTxt.ExecuteReader();
            dr.Read();
            SqlCommand cmdTxt2 = new SqlCommand("Update Medicine Set Quantity = @aa WHERE MedicineId = @ab",connPatient);
            int newQuantity = (int)dr.GetInt64(0) - Quantity;
            cmdTxt2.Parameters.Add("@aa", SqlDbType.BigInt).Value = newQuantity;
            cmdTxt2.Parameters.Add("@ab", SqlDbType.Int).Value = MedicineId;
            dr.Close();
            cmdTxt2.ExecuteNonQuery();
            
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }
    
    public bool UpdateMedicine(int MedicineId,string MedicineName, string CategoryName, int Quantity)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("Update Medicine SET MedicineName = @MedicineName,"+
            "CategoryId = (SELECT CategoryId FROM Category WHERE CategoryName = @CategoryName),"+
            "Quantity = @Quantity WHERE MedicineId ="+MedicineId, connPatient);
        cmdTxt.Parameters.Add("@MedicineName", SqlDbType.Char).Value = MedicineName;
        cmdTxt.Parameters.Add("@Quantity", SqlDbType.BigInt).Value = Quantity;
        cmdTxt.Parameters.Add("@CategoryName", SqlDbType.Char).Value = CategoryName;
        int checker = cmdTxt.ExecuteNonQuery();
        if (checker > 0)
            return true;
        else
            return false;
    }

    public List<string> GetDiseaseCategory()
    {
        List<string> category;
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        category = new List<string>();
        SqlCommand cmdTxt = new SqlCommand("Select DiseaseCategoryName From DiseaseCategory", connPatient);
        SqlDataReader dr = cmdTxt.ExecuteReader();
        while (dr.Read())
        {
            category.Add(dr.GetString(0).ToString().Trim());
        }
        dr.Close();
        connPatient.Close();
        return category;            
    }

    public void LoadCheckBoxList(CheckBoxList checkBoxDisease,string DiseaseCategory)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        try
        {
            connPatient.Open();
            SqlCommand cmdTxt = new SqlCommand("Select DiseaseName From Diseases Where DiseaseCategoryName = @DiseaseCategory", connPatient);
            cmdTxt.Parameters.Add("@DiseaseCategory", SqlDbType.Char).Value = DiseaseCategory;

            SqlDataReader dr = cmdTxt.ExecuteReader();
            while (dr.Read())
            {
                checkBoxDisease.Items.Add(dr.GetString(0).ToString().Trim());
            }
            dr.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    /*Not Yet Finished for PopUp Window*/

    public void LoadPatientGrid(GridView gridview)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        SqlCommand cmdTxt;
        DataTable dt;
        DataSet ds;
        SqlDataReader dr;
        try
        {
            connPatient.Open();
            
            cmdTxt = new SqlCommand("SELECT a.PatientID as PatientId,a.PtLname + ',' + a.PtFname + ' ' + a.PtMname as Name,c.BarangayID,c.BarangayName as Barangay FROM Patients a,"
            + "PatientsLocation b,Barangays c WHERE a.PatientID = b.PatientID AND c.BarangayID = b.BarangayID", connPatient);

            dr = cmdTxt.ExecuteReader();
            dt = new DataTable();
            dt.Columns.Add("PatientId");
            dt.Columns.Add("Name");
            dt.Columns.Add("Barangay");
            while (dr.Read())
            {
                dt.Rows.Add(dr["PatientId"].ToString(), dr["Name"].ToString(), dr["Barangay"].ToString());
            }
            dr.Close();
            
            ds = new DataSet();
            ds.Tables.Add(dt);
            MessageBox.Show("" + ds.Tables.Count.ToString());
            gridview.DataSource = null;
            gridview.DataBind();
            gridview.Dispose();
            gridview.DataSource = ds;
            gridview.DataBind();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    public void LoadIndicator(string Program,DropDownList dropdownIndicator)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        try
        {
            connPatient.Open();
            SqlCommand cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID = (SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @Program)", connPatient);
            cmdTxt.Parameters.Add("@Program", SqlDbType.Char).Value = Program;

            SqlDataReader dr = cmdTxt.ExecuteReader();
            while (dr.Read())
            {
                dropdownIndicator.Items.Add(dr.GetString(0).Trim());
            }
            dr.Close();
            
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    public int GetIndicatorId(string IndicatorData)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("SELECT IndicatorID FROM Indicator WHERE IndicatorData = @IndicatorData", connPatient);
        cmdTxt.Parameters.Add("@IndicatorData", SqlDbType.Char).Value = IndicatorData.Trim();

        SqlDataReader dr = cmdTxt.ExecuteReader();
        dr.Read();
        int id = dr.GetInt32(0);
        dr.Close();
        connPatient.Close();
        return id;
    }

    public string GetIndicatorName(int IndicatorId)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE IndicatorID = @IndicatorId", connPatient);
        cmdTxt.Parameters.Add("@IndicatorId", SqlDbType.Int).Value = IndicatorId;

        SqlDataReader dr = cmdTxt.ExecuteReader();
        dr.Read();
        string data = dr.GetString(0);
        dr.Close();
        connPatient.Close();
        return data;
    }

    public void LoadBarangays(GridView gridview)
    {
        gridview.Dispose();

        DataTable dtGrid = new DataTable();
        dtGrid.Columns.Add("Barangay"); 
        dtGrid.Columns.Add("Population");
        dtGrid.Columns.Add("Target");
        dtGrid.Columns.Add("month1");
        dtGrid.Columns.Add("month2");
        dtGrid.Columns.Add("month3");
        dtGrid.Columns.Add("Quarter Accomplishment");
        dtGrid.Columns.Add("Percent");

        SqlConnection connPatient = new SqlConnection(dataconnection);
        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("SELECT BarangayName FROM Barangays", connPatient);
        SqlDataReader dr = cmdTxt.ExecuteReader();

        while(dr.Read())
        {
            dtGrid.Rows.Add(dr.GetString(0).Trim(),"","","","","","","");
        }

        dr.Close();

        gridview.DataSource = dtGrid;
        gridview.DataBind();
        connPatient.Close();
    }

    public void InsertMalariaReport(string MalariaData,int Pregnant, int Male, int Female, int BarangayID,
        int Month, int Year)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        mc = new MonthConverter();

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Malaria (MalariaData,Pregnant,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@MalariaData,@Pregnant,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)", connPatient);
        cmdTxt.Parameters.Add("@MalariaData", SqlDbType.VarChar).Value = MalariaData;
        cmdTxt.Parameters.Add("@Pregnant", SqlDbType.Int).Value = Pregnant;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy HH:MM");
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();

        connPatient.Close();
    }

    public void InsertChildReport(string ChildData,int Male,int Female,int BarangayID, 
        int Month, int Year)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        mc = new MonthConverter();

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO ChildCare (ChildData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            +"VALUES (@ChildData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)", connPatient);
        cmdTxt.Parameters.Add("@ChildData", SqlDbType.VarChar).Value = ChildData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy HH:MM");
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
  

        connPatient.Close();
    }

    public void InsertTbReport(string TuberculosisData, int Male, int Female, int BarangayID,
        int Month, int Year)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        mc = new MonthConverter();

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Tuberculosis (TuberculosisData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@TbData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)", connPatient);
        cmdTxt.Parameters.Add("@TbData", SqlDbType.VarChar).Value = TuberculosisData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy HH:MM");
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
   
        connPatient.Close();
    }

    public void InsertSchisReport(string SchisData, int Male, int Female, int BarangayID,
       int Month, int Year)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        mc = new MonthConverter();

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Schisto (SchistoData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@SchisData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)", connPatient);
        cmdTxt.Parameters.Add("@SchisData", SqlDbType.VarChar).Value = SchisData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy HH:MM");
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();

        connPatient.Close();
    }

    public void InsertFilariasisReport(string FilariasisData, int Male, int Female, int BarangayID,
       int Month, int Year)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        mc = new MonthConverter();

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Filariasis (FilariasisData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@FilariasisData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)", connPatient);
        cmdTxt.Parameters.Add("@FilariasisData", SqlDbType.VarChar).Value = FilariasisData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy HH:MM");
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();

        connPatient.Close();
    }
    public void InsertFPReport(string FPData, int SU, int New, int Others,int DO,
       int EU,int BarangayID,int Month, int Year)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        mc = new MonthConverter();

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO FamilyPlanning (FPData,StartUser,New,Others,DropOut,EndUser,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@FPData,@SU,@New,@Others,@DO,@EU,@InputDate,@BarangayID,@Month,@Year,@Quarter)", connPatient);
        cmdTxt.Parameters.Add("@FPData", SqlDbType.VarChar).Value = FPData;
        cmdTxt.Parameters.Add("@SU", SqlDbType.Int).Value = SU;
        cmdTxt.Parameters.Add("@New", SqlDbType.Int).Value = New;
        cmdTxt.Parameters.Add("@Others", SqlDbType.Int).Value = Others;
        cmdTxt.Parameters.Add("@DO", SqlDbType.Int).Value = DO;
        cmdTxt.Parameters.Add("@EU", SqlDbType.Int).Value = EU;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy HH:MM");
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
    

        connPatient.Close();
    }

    public void InsertDentalCareReport(string DentalData, int Male, int Female, int BarangayID,
        int Month, int Year)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        mc = new MonthConverter();

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO DentalCare (DentalData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@DentalData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)", connPatient);
        cmdTxt.Parameters.Add("@DentalData", SqlDbType.VarChar).Value = DentalData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy HH:MM");
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();

        connPatient.Close();
    }

    public void InsertLeprosyReport(string LeprosyData, int Male, int Female, int BarangayID,
        int Month, int Year)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        mc = new MonthConverter();

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Leprosy (LeprosyData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@LeprosyData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)", connPatient);
        cmdTxt.Parameters.Add("@LeprosyData", SqlDbType.VarChar).Value = LeprosyData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy HH:MM");
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
   
        connPatient.Close();
    }

    public bool HasDataForTheYear(int Year,string Month, int BarangayID)
    {
        int count = 0;
        mc = new MonthConverter();
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();

        SqlCommand cmdTxt = new SqlCommand("SELECT COUNT(*) FROM MaternalCare WHERE Year = " +
            "@year AND BarangayID = @barangayID AND Month = @month", connPatient);
        cmdTxt.Parameters.Add("@year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@month", SqlDbType.Int).Value = mc.MonthNameToIndex(Month);
        cmdTxt.Parameters.Add("@barangayID", SqlDbType.Int).Value = BarangayID;
        count = (int)cmdTxt.ExecuteScalar();

        connPatient.Close();

        if (count > 0)
            return true;
        else
            return false;
    }

    //COMPLETE LAKHI
    public bool InsertPopulation(int BarangayID,int Population,int Target,int Month, int Year)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        mc = new MonthConverter();

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Population (BarangayID,Population,Target,Month,Year)"
            + "VALUES (@BarangayID,@Population,@Target,@Month,@Year)", connPatient);
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Population", SqlDbType.Int).Value = Population;
        cmdTxt.Parameters.Add("@Target", SqlDbType.Int).Value = Target;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;



        int checker = cmdTxt.ExecuteNonQuery();

        connPatient.Close();

        if (checker > 0)
            return true;
        else
            return false;
    }

    //COMPLETE LAKHI
    public void InsertMaternalCareReport(string MaternalData, int NumberOfPatients, int BarangayID,
        int Month, int Year)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        mc = new MonthConverter();

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO MaternalCare (MaternalData,NumberOfPatients,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@MaternalData,@NumberOfPatients,@InputDate,@BarangayID,@Month,@Year,@Quarter)", connPatient);
        cmdTxt.Parameters.Add("@MaternalData", SqlDbType.VarChar).Value = MaternalData;
        cmdTxt.Parameters.Add("@NumberOfPatients", SqlDbType.Int).Value = NumberOfPatients;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy HH:MM");
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        //cmdTxt.Parameters.Add("@Accomplishment", SqlDbType.VarChar).Value = Accomplishment;
        //cmdTxt.Parameters.Add("@Percent", SqlDbType.Decimal).Value = percent;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
     
        connPatient.Close();
    }
    public int GetBarangayID(string BarangayName)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("SELECT BarangayID FROM Barangays WHERE BarangayName = @BarangayName", connPatient);
        cmdTxt.Parameters.Add("@BarangayName", SqlDbType.VarChar).Value = BarangayName;
        SqlDataReader dr = cmdTxt.ExecuteReader();
        dr.Read();
        int id = dr.GetInt32(0);
        dr.Close();
        
        connPatient.Close();
        return id;
    }

    public string GetBarangayName(int BarangayID)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("SELECT BarangayName FROM Barangays WHERE BarangayID = @BarangayID", connPatient);
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.VarChar).Value = BarangayID;
        SqlDataReader dr = cmdTxt.ExecuteReader();
        dr.Read();
        string BarangayName = dr.GetString(0);
        dr.Close();

        connPatient.Close();
        return BarangayName;
    }
    public void LoadGridChildCare(GridView gridviewCCChildCare, string IndicatorData,string Quarter, string Year)
    {
        SqlConnection conn = new SqlConnection(dataconnection);
        SqlDataReader dr;
        conn.Open();
        SqlCommand cmdTxt = new SqlCommand("GetcChildCare", conn);
        cmdTxt.CommandType = CommandType.StoredProcedure;
        cmdTxt.Parameters.Add("@IndicatorData", SqlDbType.VarChar).Value = IndicatorData;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = Convert.ToInt32(Quarter);
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Int32.Parse(Year);
        //cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        dr = cmdTxt.ExecuteReader();
        
        gridviewCCChildCare.DataSource = dr;
        gridviewCCChildCare.DataBind();
        
        dr.Dispose();
        conn.Close();
    }
    public void LoadAvailableYearAndMonth(string Program, DropDownList year, DropDownList month)
    {
        SqlConnection conn = new SqlConnection(dataconnection);
        SqlDataReader drYear;
        SqlDataReader drMonth;
        conn.Open();
        SqlCommand cmdTxtYear = new SqlCommand("Select Distinct Year From "+Program.Trim(), conn);
        SqlCommand cmdTxtMonth = new SqlCommand("Select Distinct Month From "+Program.Trim(), conn);

        drYear = cmdTxtYear.ExecuteReader();
        year.Items.Add("All");
        while (drYear.Read())
        {
            year.Items.Add(drYear.GetInt32(0).ToString());
        }
        drYear.Close();
        
        drMonth = cmdTxtMonth.ExecuteReader();
        month.Items.Add("All");
        while (drMonth.Read())
        {
            month.Items.Add(drMonth.GetInt32(0).ToString());
        }
        drMonth.Close();

        drYear.Dispose();
        drMonth.Dispose();
        conn.Close();
    }

    public void SavePatientDailyMedicalRecord(int PatientID, int PatientAge, decimal Temperature, decimal PatientWeight, string PatientHeight
        , string BloodPressure, string Diagnosis, string Treatment, string userAccount)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Encounters (EncounterDateTime,PatientID,Age,Temp,Weight,Height,Bloodpressure,Diagnosis,Treatment,Facilitatedby)"
            + "VALUES (@EncounterDateTime,@PatientID,@Age,@Temp,@Weight,@Height,@Bloodpressure,@Diagnosis,@Treatment,@Facilitatedby)", connPatient);
        cmdTxt.Parameters.Add("@EncounterDateTime", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy HH:MM");
        cmdTxt.Parameters.Add("@PatientID", SqlDbType.Int).Value = PatientID;
        cmdTxt.Parameters.Add("@Age", SqlDbType.Int).Value = PatientAge;
        cmdTxt.Parameters.Add("@Temp", SqlDbType.Decimal).Value = Temperature;
        cmdTxt.Parameters.Add("@Weight", SqlDbType.Decimal).Value = PatientWeight;
        cmdTxt.Parameters.Add("@Height", SqlDbType.VarChar).Value = PatientHeight;
        cmdTxt.Parameters.Add("@Bloodpressure", SqlDbType.VarChar).Value = BloodPressure;
        
        cmdTxt.Parameters.Add("@Diagnosis", SqlDbType.VarChar).Value = Diagnosis;
        cmdTxt.Parameters.Add("@Treatment", SqlDbType.VarChar).Value = Treatment;
        cmdTxt.Parameters.Add("@Facilitatedby", SqlDbType.VarChar).Value = userAccount;
        cmdTxt.ExecuteNonQuery();
    }
    public bool HasPatient(string firstName, string middleName, string lastname, string address)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("SELECT COUNT(*) FROM Patients WHERE PtFname = @firstname AND PtMname = @middlename" +
            " AND PtLname = @lastname AND PtAddress = @address", connPatient);
        cmdTxt.Parameters.Add("@firstname", SqlDbType.VarChar).Value = firstName;
        cmdTxt.Parameters.Add("@middlename", SqlDbType.VarChar).Value = middleName;
        cmdTxt.Parameters.Add("@lastname", SqlDbType.VarChar).Value = lastname;
        cmdTxt.Parameters.Add("@address", SqlDbType.VarChar).Value = address;

        if ((int)cmdTxt.ExecuteScalar() > 0)
            return true;
        else
            return false;
    }
    public bool HasMedicine(int MedicineId)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("SELECT COUNT(*) FROM Medicine WHERE MedicineId = @medicineId", connPatient);
        cmdTxt.Parameters.Add("@medicineId", SqlDbType.Int).Value = MedicineId;

        if ((int)cmdTxt.ExecuteScalar() > 0)
            return true;
        else
            return false;
    }
    public bool HasMedicineName(string MedicineName)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("SELECT COUNT(*) FROM Medicine WHERE MedicineName = @medicineName", connPatient);
        cmdTxt.Parameters.Add("@medicineName", SqlDbType.VarChar).Value = MedicineName;

        if ((int)cmdTxt.ExecuteScalar() > 0)
            return true;
        else
            return false;
    }
    public string GetMedicineName(int MedicineId)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();

        SqlCommand cmdTxt = new SqlCommand("SELECT MedicineName FROM Medicine WHERE MedicineId = @aa", connPatient);
        cmdTxt.Parameters.Add("@aa", SqlDbType.Int).Value = MedicineId;
        SqlDataReader name = cmdTxt.ExecuteReader();
        name.Read();
        string medName = name.GetString(0);
        name.Close();
        connPatient.Close();
        return medName;
    }
    public int CountIndicatorPerProgram(string Program)
    {
        int count = 0;
        SqlConnection connPatient = new SqlConnection(dataconnection);

        connPatient.Open();

        SqlCommand cmdTxt = new SqlCommand("SELECT COUNT(*) FROM Indicator WHERE ProgramCategoryID = " +
            "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)", connPatient);
        cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = Program;
        count = (int)cmdTxt.ExecuteScalar();
        
        connPatient.Close();

        return count;
    }

    public DataTable GetEncounterData(string EncounterId)
    {
        DataTable ptEncounterData = new DataTable();
        SqlConnection connPatient = new SqlConnection(dataconnection);
        SqlDataReader dtrPatient;

        ptEncounterData.Columns.Add("Age");
        ptEncounterData.Columns.Add("Temp");
        ptEncounterData.Columns.Add("Weight");
        ptEncounterData.Columns.Add("Height");
        ptEncounterData.Columns.Add("Bloodpressure");
        ptEncounterData.Columns.Add("Diagnosis");
        ptEncounterData.Columns.Add("Treatment");

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("SELECT Age,Temp,Weight,Height,Bloodpressure,Diagnosis,Treatment FROM Encounters WHERE EncounterID = @encId", connPatient);
        cmdTxt.Parameters.Add("@encId", SqlDbType.Int).Value = Int32.Parse(EncounterId);
        dtrPatient = cmdTxt.ExecuteReader();
        dtrPatient.Read();

        ptEncounterData.Rows.Add(dtrPatient["Age"].ToString().Trim(), dtrPatient["Temp"].ToString().Trim(),
            dtrPatient["Weight"].ToString().Trim(), dtrPatient["Height"].ToString().Trim()
            , dtrPatient["Bloodpressure"].ToString().Trim(), dtrPatient["Diagnosis"].ToString().Trim(), dtrPatient["Treatment"].ToString().Trim());
        return ptEncounterData;
    }

    public DataTable GetNameForMedHistory(string Patient_Id)
    {
        SqlConnection connPatient = new SqlConnection(dataconnection);
        SqlDataReader dtrPatient;
        DataTable patientData = new DataTable();


        patientData.Columns.Add("PatientLName");
        patientData.Columns.Add("PatientFName");
        patientData.Columns.Add("PatientMName");
        patientData.Columns.Add("PatientBarangay");

        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("GetPatientData", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@Patient_Id", SqlDbType.Char).Value = Patient_Id;
            dtrPatient = cmdTxt.ExecuteReader();
            dtrPatient.Read();

            patientData.Rows.Add(dtrPatient["PtLname"].ToString().Trim(), dtrPatient["PtFname"].ToString().Trim(),
                dtrPatient["PtMname"].ToString().Trim(), dtrPatient["BarangayName"].ToString().Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show("No Patient Found for Patient ID: " + Patient_Id);
        }
        finally
        {
            connPatient.Close();
        }
        return patientData;
    }
}
