<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="RestAPIClientInterface.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style>

table {
    font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
    border-collapse: collapse;
    width: 100%;
}

td, th {
    border: 1px solid #ddd;
    text-align: left;
    padding: 8px;
}

tr:nth-child(even){background-color: #f2f2f2}

tr:hover {background-color: #ddd;}

th {
    padding-top: 12px;
    padding-bottom: 12px;
    background-color: gray;

    color: white;
}


#dvCustomersTitle, #dvCustomers, #dvCustomerGroupsTitle, #dvCustomerGroups, #dvProductsTitle, #dvProducts, #dvCategoriesTitle, #dvCategories, #dvOrdersTitle, #dvOrders, #dvManufacturersTitle, #dvManufacturers, #dvDistributorsTitle, #dvDistributors   {
    padding: 5px;
    text-align: left;
    background-color: lightgray ;
    border: solid 1px #c3c3c3;
}

#dvCustomers, #dvCustomerGroups, #dvProducts, #dvCategories, #dvOrders, #dvManufacturers, #dvDistributors {
    padding: 15px;
    display: none;
}

</style>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script>
        $(document).ready(function () {

            //Customers - Show or hide divs based on button clicked, i-e, GET, ADD, UPDATE, DELETE
            $("#btnCustomerGet").click(function () {
                ShowHideDiv("Get", "Customers");
            });

            $("#btnCustomerPost").click(function () {
                ShowHideDiv("Post", "Customers");
                //$("#dvCustomersControlsAdd").show();
            });

            $("#btnCustomerPut").click(function () {
                ShowHideDiv("Put", "Customers");
                //Only for Customers section - Hide EMail and password fields during Update
                //$("#dvCustomersControlsAdd").hide();

            });

            $("#btnCustomerDel").click(function () {
                ShowHideDiv("Del", "Customers");
            });

            //Show effects based on the option clicked
            $("#dvCustomersTitle").click(function () {
                $("#dvCustomers").slideToggle("slow");
                $("#dvCustomersDetail").slideToggle();
            });




            //Customer Groups - Show or hide divs based on button clicked, i-e, GET, ADD, UPDATE, DELETE
            $("#btnCustomerGroupGet").click(function () {
                ShowHideDiv("Get", "CustomerGroups");
            });

            $("#btnCustomerGroupPost").click(function () {
                ShowHideDiv("Post", "CustomerGroups");
            });

            $("#btnCustomerGroupPut").click(function () {
                ShowHideDiv("Put", "CustomerGroups");
            });

            $("#btnCustomerGroupDel").click(function () {
                ShowHideDiv("Del", "CustomerGroups");
            });

            //Show effects based on the option clicked
            $("#dvCustomerGroupsTitle").click(function () {
                $("#dvCustomerGroups").slideToggle("slow");
                $("#dvCustomerGroupsDetail").slideToggle();
            });




            //Products - Show or hide divs based on button clicked, i-e, GET, ADD, UPDATE, DELETE
            $("#btnProductGet").click(function () {
                ShowHideDiv("Get", "Products");
            });

            $("#btnProductPost").click(function () {
                ShowHideDiv("Post", "Products");
            });

            $("#btnProductPut").click(function () {
                ShowHideDiv("Put", "Products");
            });

            $("#btnProductDel").click(function () {
                ShowHideDiv("Del", "Products");
            });

            //Show effects based on the option clicked
            $("#dvProductsTitle").click(function () {
                $("#dvProducts").slideToggle("slow");
                $("#dvProductsDetail").slideToggle();
            });


            //Categories- Show or hide divs based on button clicked, i-e, GET, ADD, UPDATE, DELETE
            $("#btnCategoryGet").click(function () {
                ShowHideDiv("Get", "Categories");
            });

            $("#btnCategoryPost").click(function () {
                ShowHideDiv("Post", "Categories");
            });

            $("#btnCategoryPut").click(function () {
                ShowHideDiv("Put", "Categories");
            });

            $("#btnCategoryDel").click(function () {
                ShowHideDiv("Del", "Categories");
            });

            //Show effects based on the option clicked
            $("#dvCategoriesTitle").click(function () {
                $("#dvCategories").slideToggle("slow");
                $("#dvCategoriesDetail").slideToggle();
            });



            //Orders - Show or hide divs based on button clicked, i-e, GET, ADD, UPDATE, DELETE
            $("#btnOrderGet").click(function () {
                ShowHideDiv("Get", "Orders");
            });

            $("#btnOrderPost").click(function () {
                ShowHideDiv("Post", "Orders");
            });

            $("#btnOrderPut").click(function () {
                ShowHideDiv("Put", "Orders");
            });

            $("#btnOrderDel").click(function () {
                ShowHideDiv("Del", "Orders");
            });

            //Show effects based on the option clicked
            $("#dvOrdersTitle").click(function () {
                $("#dvOrders").slideToggle("slow");
                $("#dvOrdersDetail").slideToggle();
            });



            //Manufacturers - Show or hide divs based on button clicked, i-e, GET, ADD, UPDATE, DELETE
            $("#btnManufacturerGet").click(function () {
                ShowHideDiv("Get", "Manufacturers");
            });

            $("#btnManufacturerPost").click(function () {
                ShowHideDiv("Post", "Manufacturers");
            });

            $("#btnManufacturerPut").click(function () {
                ShowHideDiv("Put", "Manufacturers");
            });

            $("#btnManufacturerDel").click(function () {
                ShowHideDiv("Del", "Manufacturers");
            });

            //Show effects based on the option clicked
            $("#dvManufacturersTitle").click(function () {
                $("#dvManufacturers").slideToggle("slow");
                $("#dvManufacturersDetail").slideToggle();
            });



            //Distributors - Show or hide divs based on button clicked, i-e, GET, ADD, UPDATE, DELETE
            $("#btnDistributorGet").click(function () {
                ShowHideDiv("Get", "Distributors");
            });

            $("#btnDistributorPost").click(function () {
                ShowHideDiv("Post", "Distributors");
            });

            $("#btnDistributorPut").click(function () {
                ShowHideDiv("Put", "Distributors");
            });

            $("#btnDistributorDel").click(function () {
                ShowHideDiv("Del", "Distributors");
            });

            //Show effects based on the option clicked
            $("#dvDistributorsTitle").click(function () {
                $("#dvDistributors").slideToggle("slow");
                $("#dvDistributorsDetail").slideToggle();
            });


          }
        );

        function ShowHideDiv(action, restAPIName)
        {
            if (action == "Get")
            {
                $("#dv" + restAPIName + "ID").show();
                $("#dv" + restAPIName + "Get").show();
                $("#dv" + restAPIName + "Controls").hide();
                $("#dv" + restAPIName + "Add").hide();
                $("#dv" + restAPIName + "ControlsAdd").hide();
                $("#dv" + restAPIName + "Update").hide();
                $("#dv" + restAPIName + "DEL").hide();
                $("#dv" + restAPIName + "ID input").val('');

            }

            else if (action == "Post")

            {
                $("#dv" + restAPIName + "ID").hide();
                $("#dv" + restAPIName + "Get").hide();
                $("#dv" + restAPIName + "Controls").show();
                $("#dv" + restAPIName + "ControlsAdd").show();
                $("#dv" + restAPIName + "Add").show();
                $("#dv" + restAPIName + "Update").hide();
                $("#dv" + restAPIName + "DEL").hide();
                $("#dv" + restAPIName + "ID input").val('');
                $("#dv" + restAPIName + "Controls input").val('');
                $("#dv" + restAPIName + "ControlsAdd input").val('');

            }

            else if (action == "Put")
            {

                $("#dv" + restAPIName + "ID").show();
                $("#dv" + restAPIName + "Get").hide();
                $("#dv" + restAPIName + "Controls").show();
                $("#dv" + restAPIName + "ControlsAdd").hide();
                $("#dv" + restAPIName + "Add").hide();
                $("#dv" + restAPIName + "Update").show();
                $("#dv" + restAPIName + "DEL").hide();

            }

            else if (action == "Del")
            {

                $("#dv" + restAPIName + "ID").show();
                $("#dv" + restAPIName + "Get").hide();
                $("#dv" + restAPIName + "Controls").hide();
                $("#dv" + restAPIName + "ControlsAdd").hide();
                $("#dv" + restAPIName + "Add").hide();
                $("#dv" + restAPIName + "Update").hide();
                $("#dv" + restAPIName + "DEL").show();
                $("#dv" + restAPIName + "ID input").val('');
            }

            ClearControls(action, restAPIName);

        }

        function ClearControls(action, restAPIName)
        {
            if (action == "Get") {
                $("#dv" + restAPIName + "ID input").val('');
            }

            else if (action == "Post") {
                $("#dv" + restAPIName + "ID input").val('');
                $("#dv" + restAPIName + "Controls input").val('');
            }

            else if (action == "Put") {
                $("#dv" + restAPIName + "ID input").val('');
                $("#dv" + restAPIName + "Controls input").val('');
            }

            else if (action == "Del") {
                $("#dv" + restAPIName + "ID input").val('');
            }

        }

        //Generic function to add a record
        function AddRecord(RestAPIObject, restAPIType, RestAPIUpdateID ) {

            var RestAPIType = restAPIType;
            var RestAPIUpdateID = RestAPIUpdateID;

            var PrivateKey = $('#txtPrivateKey')[0].value;
            var Token = $('#txtToken')[0].value;
            var SecureURL = $('#txtSecureURL')[0].value;

            if (PrivateKey == "" || Token == "" || SecureURL == "") {
                alert("At least one of the following fields is missing: Private Key, Token, Secure URL");
                return;
            }

            var jsonObject = JSON.stringify({ 'RestAPIObject': RestAPIObject, 'RestAPIType': RestAPIType, 'PrivateKey': PrivateKey, 'Token': Token, 'SecureURL': SecureURL });

            $.ajax({
                type: "POST",
                url: "Main.aspx/AddRecord",
                data: jsonObject,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function OnSuccessRecordAdd(response)
                {
                    alert(response.d);
                    if (response.d.indexOf("Error") == -1) {
                        ClearControls("Post", restAPIType)
                    }
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }


        //Generic function to update a record
        function UpdateRecord(RestAPIObject, restAPIType, RestAPIUpdateID) {

            var RestAPIType = restAPIType; 
            var RestAPIUpdateID = RestAPIUpdateID;

            var PrivateKey = $('#txtPrivateKey')[0].value;
            var Token = $('#txtToken')[0].value;
            var SecureURL = $('#txtSecureURL')[0].value;

            if (PrivateKey == "" || Token == "" || SecureURL=="") {
                alert("At least one of the following fields is missing: Private Key, Token, Secure URL");
                return;
            }

            if (RestAPIUpdateID == "") {
                alert("Record to update must be specified");
                return;
            }


            var jsonObject = JSON.stringify({ 'RestAPIObject': RestAPIObject, 'RestAPIType': RestAPIType, 'RestAPIUpdateID': RestAPIUpdateID, 'PrivateKey': PrivateKey, 'Token': Token, 'SecureURL': SecureURL });

            $.ajax({
                type: "POST",
                url: "Main.aspx/UpdateRecord",
                data: jsonObject,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function OnSuccessRecordUpdate(response)
                {

                    if (response.d == "") {
                        alert("No Record found.");
                        ClearControls("Put", RestAPIType);
                        return;
                    }

                    alert(response.d);
                    if (response.d.indexOf("Error") == -1) {
                        ClearControls("Put", restAPIType)
                    }
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }


        //Generic function to delete a record
        function DeleteRecord(restAPIType, RestAPIDeleteID) {
            var RestAPIType = restAPIType;
            var RestAPIDeleteID = RestAPIDeleteID;

            var PrivateKey = $('#txtPrivateKey')[0].value;
            var Token = $('#txtToken')[0].value;
            var SecureURL = $('#txtSecureURL')[0].value;

            if (PrivateKey == "" || Token == "" || SecureURL == "") {
                alert("At least one of the following fields is missing: Private Key, Token, Secure URL");
                return;
            }

            if (RestAPIDeleteID == "") {
                alert("Record to delete must be specified");
                return;
            }

            var jsonObject = JSON.stringify({'RestAPIType': RestAPIType, 'RestAPIDeleteID': RestAPIDeleteID, 'PrivateKey': PrivateKey, 'Token': Token, 'SecureURL': SecureURL });

            $.ajax({
                type: "POST",
                url: "Main.aspx/DeleteRecord",
                data: jsonObject,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function OnSuccessRecordDelete(response) {

                    if (response.d == "") {
                        alert("No Record found.");
                        ClearControls("Del", RestAPIType);
                        return;
                    }

                    alert(response.d);
                    if (response.d.indexOf("Error") == -1) {
                        ClearControls("Del", restAPIType)
                    }
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }


        //----------------------------------------------------------------------------------------//
        //GET Section
        function GetRecords(RestAPIType, RestAPISelectID, RecordsGetLimit) {

            var PrivateKey = $('#txtPrivateKey')[0].value;
            var Token = $('#txtToken')[0].value;
            var SecureURL = $('#txtSecureURL')[0].value;

            if (PrivateKey == "" || Token == "" || SecureURL == "") {
                alert("At least one of the following fields is missing: Private Key, Token, Secure URL");
                return;
            }

            var jsonObject = JSON.stringify({ 'strRestAPIID': RestAPISelectID, 'RestAPIType': RestAPIType, 'PrivateKey': PrivateKey, 'Token': Token, 'SecureURL': SecureURL, 'RecordsGetLimit': RecordsGetLimit });

            $.ajax({
                type: "POST",
                url: "Main.aspx/GetRestAPIRecords",
                data: jsonObject,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function OnSuccess(response)
                {

                    if (response.d == "") {
                        alert("No Record found.");
                        ClearControls("Get", RestAPIType);
                        ClearControls("Put", RestAPIType);
                        return;
                    }


                    var obj = JSON.parse(response.d);

                    //Populate Customers
                    if (RestAPIType == 'Customers') {

                        //Populate Customer text boxes

                        $("#txtEMail").val(obj[0].Email);
                        $("#txtPassword").val(obj[0].Password);
                        $("#txtBillCompany").val(obj[0].BillingCompany);
                        $("#txtBillFirstName").val(obj[0].BillingFirstName);
                        $("#txtBillLastName").val(obj[0].BillingLastName);

                        //Create a Customer table
                        drawTable(obj, RestAPIType);
                    } 

                    //Populate CustomerGroups
                    else if (RestAPIType == 'CustomerGroups') {

                        //Populate Customer Group text boxes
                        $("#txtCGroupName").val(obj[0].Name);
                        $("#txtCGroupDescription").val(obj[0].Description);
                        $("#txtCGroupMinimumOrder").val(obj[0].MinimumOrder);
                        $("#txtCGroupRegistrationMessage").val(obj[0].RegistrationMessage);

                        //Create a Customer Groups table
                        drawTable(obj, RestAPIType);
                    }

                    //Populate Products
                    else if (RestAPIType == 'Products') {

                        //Populate Product text boxes
                        $("#txtSKU").val(obj[0].SKUInfo.SKU);
                        $("#txtSKUName").val(obj[0].SKUInfo.Name);
                        $("#txtSKUPrice").val(obj[0].SKUInfo.Price);
                        $("#txtSKUCost").val(obj[0].SKUInfo.Cost);

                        //Create a Products table
                        drawTable(obj, RestAPIType);
                    }

                    //Populate Categories
                    else if (RestAPIType == 'Categories') {

                        //Populate Category text boxes
                        $("#txtCategoryName").val(obj[0].CategoryName);
                        $("#txtCategoryDescription").val(obj[0].CategoryDescription);

                        //Create a Categories table
                        drawTable(obj, RestAPIType);
                    }

                    //Populate Orders
                    else if (RestAPIType == 'Orders') {

                        //Populate Order text boxes
                        $("#txtInvoiceNumberPrefix").val(obj[0].InvoiceNumberPrefix);
                        $("#txtInvoiceNumber").val(obj[0].InvoiceNumber);
                        $("#txtOrderCustomerID").val(obj[0].CustomerID);
                        $("#txtOrderDate").val(obj[0].OrderDate);
                        $("#txtOrderStatusID").val(obj[0].OrderStatusID);
                        $("#txtOrderBillingFirstName").val(obj[0].BillingFirstName);
                        $("#txtOrderBillingLastName").val(obj[0].BillingLastName);
                        $("#txtOrderBillingPhone").val(obj[0].BillingPhoneNumber);
                        $("#txtOrderBillingAddress").val(obj[0].BillingAddress);
                        $("#txtOrderBillingCity").val(obj[0].BillingCity);
                        $("#txtOrderBillingCountry").val(obj[0].BillingCountry);
                        $("#txtOrderBillingState").val(obj[0].BillingState);
                        $("#txtOrderBillingZip").val(obj[0].BillingZipCode);
                        $("#txtOrderBillingEMail").val(obj[0].BillingEmail);

                        //Create a Orders table
                        drawTable(obj, RestAPIType);
                    }

                    //Populate Manufacturers
                    else if (RestAPIType == 'Manufacturers') {

                        //Populate Manufacturer text boxes
                        $("#txtManufacturerName").val(obj[0].ManufacturerName);
                        $("#txtManufacturerWebsite").val(obj[0].Website);
                        $("#txtManufacturerPageTitle").val(obj[0].PageTitle);

                        //Create a Manufacturers table
                        drawTable(obj, RestAPIType);
                    }

                    //Populate Distributors
                    else if (RestAPIType == 'Distributors') {

                        //Populate Distributor text boxes
                        $("#txtDistributorCompanyName").val(obj[0].CompanyName);
                        $("#txtDistributorContactName").val(obj[0].ContactName);
                        $("#txtDistributorAddress").val(obj[0].Address);
                        $("#txtDistributorCity").val(obj[0].City);
                        $("#txtDistributorState").val(obj[0].State);

                        //Create a Distributors table
                        drawTable(obj, RestAPIType);
                    }



                },

                failure: function (response) {
                    alert(response.d);
                }
            });


        }

        //function to draw table for different API Types, like Customers, Customer Groups, Orders ...
        function drawTable(data, RestAPIType) {

            $("#" + RestAPIType + "DataTable").find("tr:gt(0)").remove();

            for (var i = 0; i < data.length; i++)
            {
                drawRow(data[i], RestAPIType);
            }

        }

        //function called by draw table to draw rows specific to each RestAPI Type
        function drawRow(rowData, RestAPIType) {
            var row = $("<tr />")
            $("#" + RestAPIType + "DataTable").append(row); //this will append tr element to table... keep its reference for a while since we will add cells into it

            if (RestAPIType == "Customers") {
                row.append($("<td>" + rowData.CustomerID + "</td>"));
                row.append($("<td>" + rowData.Email + "</td>"));
                row.append($("<td>" + rowData.BillingFirstName + "</td>"));
                row.append($("<td>" + rowData.BillingLastName + "</td>"));
            }

            else if (RestAPIType == "CustomerGroups") {
                row.append($("<td>" + rowData.CustomerGroupID + "</td>"));
                row.append($("<td>" + rowData.Name + "</td>"));
                row.append($("<td>" + rowData.Description + "</td>"));
                row.append($("<td>" + rowData.MinimumOrder + "</td>"));
                row.append($("<td>" + rowData.RegistrationMessage + "</td>"));
            }

            else if (RestAPIType == "Products") {
                row.append($("<td>" + rowData.SKUInfo.CatalogID + "</td>"));
                row.append($("<td>" + rowData.SKUInfo.SKU + "</td>"));
                row.append($("<td>" + rowData.SKUInfo.Name + "</td>"));
                row.append($("<td>" + rowData.SKUInfo.Price + "</td>"));
                row.append($("<td>" + rowData.SKUInfo.Cost + "</td>"));
            }

            else if (RestAPIType == "Distributors") {
                row.append($("<td>" + rowData.DistributorID + "</td>"));
                row.append($("<td>" + rowData.CompanyName + "</td>"));
                row.append($("<td>" + rowData.ContactName + "</td>"));
                row.append($("<td>" + rowData.Address + "</td>"));
                row.append($("<td>" + rowData.City + "</td>"));
                row.append($("<td>" + rowData.State + "</td>"));
            }

            else if (RestAPIType == "Manufacturers") {
                row.append($("<td>" + rowData.ManufacturerID + "</td>"));
                row.append($("<td>" + rowData.ManufacturerName + "</td>"));
                row.append($("<td>" + rowData.Website + "</td>"));
                row.append($("<td>" + rowData.PageTitle + "</td>"));
            }

            else if (RestAPIType == "Categories") {
                row.append($("<td>" + rowData.CategoryID + "</td>"));
                row.append($("<td>" + rowData.CategoryName + "</td>"));
                row.append($("<td>" + rowData.CategoryDescription + "</td>"));
            }
            else if (RestAPIType == "Orders") {
                row.append($("<td>" + rowData.OrderID + "</td>"));
                row.append($("<td>" + rowData.InvoiceNumberPrefix + "</td>"));
                row.append($("<td>" + rowData.InvoiceNumber + "</td>"));
                row.append($("<td>" + rowData.CustomerID + "</td>"));
                row.append($("<td>" + rowData.OrderDate + "</td>"));
                row.append($("<td>" + rowData.OrderStatusID + "</td>"));

                row.append($("<td>" + rowData.BillingFirstName + "</td>"));
                row.append($("<td>" + rowData.BillingLastName + "</td>"));
                row.append($("<td>" + rowData.BillingPhoneNumber + "</td>"));
                row.append($("<td>" + rowData.BillingAddress + "</td>"));
                row.append($("<td>" + rowData.BillingCity + "</td>"));
                row.append($("<td>" + rowData.BillingCountry + "</td>"));
                row.append($("<td>" + rowData.BillingState + "</td>"));
                row.append($("<td>" + rowData.BillingZipCode + "</td>"));
                row.append($("<td>" + rowData.BillingEmail + "</td>"));
            }


        }


        //UPDATE Section
        //Customer Javascript - update
        function UpdateCustomer(restAPIType, RestAPIUpdateID) {

            //Create customer object
            var cust = {
                CustomerID: $("#txtCustomersID")[0].value,
                EMail: $("#txtEMail")[0].value, 
                Password: $("#txtPassword")[0].value, 
                BillingCompany: $("#txtBillCompany")[0].value, 
                BillingFirstName: $("#txtBillFirstName")[0].value, 
                BillingLastName: $("#txtBillLastName")[0].value 

            };

            //Call UpdateRecord generic javascript function to update the customer
            UpdateRecord(cust, restAPIType, RestAPIUpdateID);

        }

        function UpdateCustomerGroup(restAPIType, RestAPIUpdateID) {

            //Create Customer Group object
            var custGroup = {
                ID: $("#txtCustomerGroupsID")[0].value,
                Name: $("#txtCGroupName")[0].value,
                Description: $("#txtCGroupDescription")[0].value,
                MinimumOrder: $("#txtCGroupMinimumOrder")[0].value,
                RegistrationMessage: $("#txtCGroupRegistrationMessage")[0].value 
            };

            //Call UpdateRecord generic javascript function to update the Customer Group
            UpdateRecord(custGroup, restAPIType, RestAPIUpdateID);

        }

        function UpdateProduct(restAPIType, RestAPIUpdateID) {

            //Create product object
            var product = {
                SKUInfo: {
                    CatalogID: $("#txtProductsID")[0].value,
                    SKU: $("#txtSKU")[0].value,
                    Name: $("#txtSKUName")[0].value,
                    Price: $("#txtSKUPrice")[0].value,
                    Cost: $("#txtSKUCost")[0].value
                }
            };

            //Call UpdateRecord generic javascript function to update the Product
            UpdateRecord(product, restAPIType, RestAPIUpdateID);

        }

        function UpdateCategory(restAPIType, RestAPIUpdateID) {

            //Create Category Object
            var category = {
                    CategoryID: $("#txtCategoriesID")[0].value,
                    CategoryName: $("#txtCategoryName")[0].value,
                    CategoryDescription: $("#txtCategoryDescription")[0].value
            };

            //Call UpdateRecord generic javascript function to update the category
            UpdateRecord(category, restAPIType, RestAPIUpdateID);

        }

        function UpdateOrder(restAPIType, RestAPIUpdateID) {

            //Instead of creating Order object by taking values from text boxes, use JSON to create Order object (due to complexity of order object)
            var order = JSON.parse(txtOrderJson.value);

            //Call UpdateRecord generic javascript function to update the Order
            UpdateRecord(order, restAPIType, RestAPIUpdateID);

        }

        function UpdateManufacturer(restAPIType, RestAPIUpdateID) {

            //Create Manufacturer object
            var Manufacturer = {
                ManufacturerID: $("#txtManufacturersID")[0].value,
                ManufacturerName: $("#txtManufacturerName")[0].value,
                Website: $("#txtManufacturerWebsite")[0].value,
                PageTitle: $("#txtManufacturerPageTitle")[0].value
            };

            //Call UpdateRecord generic javascript function to update the manufacturer
            UpdateRecord(Manufacturer, restAPIType, RestAPIUpdateID);

        }

        function UpdateDistributor(restAPIType, RestAPIUpdateID) {

            //Create Distributor Object
            var Distributor = {
                DistributorID: $("#txtDistributorsID")[0].value,
                CompanyName: $("#txtDistributorCompanyName")[0].value,
                ContactName: $("#txtDistributorContactName")[0].value,
                Address: $("#txtDistributorAddress")[0].value,
                City: $("#txtDistributorCity")[0].value,
                State: $("#txtDistributorState")[0].value
            };

            //Call UpdateRecord generic javascript function to update the distributor
            UpdateRecord(Distributor, restAPIType, RestAPIUpdateID);

        }


        //Generic Keydown Event. This event fires for GET, UPDATE and DELETE
        function GetKeydown(event, restAPIType) {
            var IsUpdate = false;

            var x = event.keyCode;
            if (x == 13) {
                //Get the value from the textbox that fired the keydown event.
                var RestAPIGetID = $('#txt' + restAPIType + 'ID')[0].value;

                //If the related restAPI div controls are visible, user is on update screen 
                if ($("#dv" + restAPIType + "Controls").is(":visible")) {
                    IsUpdate = true;
                }

                //If user is on update screen, clear the controls 
                if (IsUpdate && RestAPIGetID == "") {
                    ClearControls("Put", restAPIType);
                    return;

                }

                //Get the maxinum of 100 record(s) for a RestAPType by calling GetRecords function.
                GetRecords(restAPIType, RestAPIGetID, 100);
            }
        }


        ////ADD Section
        function AddCustomer(restAPIType, RestAPIUpdateID) {

            //Create customer Object
            var cust = {
                EMail: $("#txtEMail")[0].value, 
                Password: $("#txtPassword")[0].value,
                BillingCompany: $("#txtBillCompany")[0].value,
                BillingFirstName: $("#txtBillFirstName")[0].value,
                BillingLastName: $("#txtBillLastName")[0].value 

            };

            //Call AddRecord generic javascript function to update the customer
            AddRecord(cust, restAPIType, RestAPIUpdateID);

        }

        function AddCustomerGroup(restAPIType, RestAPIUpdateID) {

            //Create customer Object
            var custGroup = {
                Name: $("#txtCGroupName")[0].value,
                Description: $("#txtCGroupDescription")[0].value,
                MinimumOrder: $("#txtCGroupMinimumOrder")[0].value,
                RegistrationMessage: $("#txtCGroupRegistrationMessage")[0].value
            };

            //Call AddRecord generic javascript function to add the customer
            AddRecord(custGroup, restAPIType, RestAPIUpdateID)

        }

        function AddProduct(restAPIType, RestAPIUpdateID) {

            //Create product Object
            var product = {
                SKUInfo: {
                    SKU: $("#txtSKU")[0].value,
                    Name: $("#txtSKUName")[0].value,
                    Price: $("#txtSKUPrice")[0].value,
                    Cost: $("#txtSKUCost")[0].value
                }
            };

            //Call AddRecord generic javascript function to add the product
            AddRecord(product, restAPIType, RestAPIUpdateID)

        }

        function AddCategory(restAPIType, RestAPIUpdateID) {

            //Create category Object
            var category = {
                CategoryName: $("#txtCategoryName")[0].value,
                CategoryDescription: $("#txtCategoryDescription")[0].value

            };

            //Call AddRecord generic javascript function to add the category
            AddRecord(category, restAPIType, RestAPIUpdateID)

        }

        function AddOrder(restAPIType, RestAPIUpdateID) {

            //Instead of creating Order object by taking values from text boxes, use JSON to create Order object (due to complexity of order object)
            var order = JSON.parse(txtOrderJson.value);

            //Call AddRecord generic javascript function to add the order
            AddRecord(order, restAPIType, RestAPIUpdateID)

        }

        function AddManufacturer(restAPIType, RestAPIUpdateID) {

            //Create manufacturer Object
            var Manufacturer = {
                ManufacturerName: $("#txtManufacturerName")[0].value,
                Website: $("#txtManufacturerWebsite")[0].value,
                PageTitle: $("#txtManufacturerPageTitle")[0].value

            };

            //Call AddRecord generic javascript function to add the manufacturer
            AddRecord(Manufacturer, restAPIType, RestAPIUpdateID)

        }

        function AddDistributor(restAPIType, RestAPIUpdateID) {

            //Create distributor Object
            var Distributor = {
                CompanyName: $("#txtDistributorCompanyName")[0].value,
                ContactName: $("#txtDistributorContactName")[0].value,
                Address: $("#txtDistributorAddress")[0].value,
                City: $("#txtDistributorCity")[0].value,
                State: $("#txtDistributorState")[0].value

            };

            //Call AddRecord generic javascript function to add the distributor
            AddRecord(Distributor, restAPIType, RestAPIUpdateID)

        }


    </script>
    <title></title>
</head>


<body>
            <div id="dvConnectionControls" >
                <table>
                    <tr>
                        <td>Private Key:</td> 
                        <td><input type="text" id="txtPrivateKey" style="width: 255px" /></td>
                    </tr>
                    <tr>
                        <td>Token:</td> 
                        <td><input type="text" id="txtToken" style="width: 255px" /> </td>
                    </tr>
                    <tr>
                        <td>Secure URL:</td> 
                        <td><input type="text" id="txtSecureURL" style="width: 350px" /> </td>
                    </tr>


                </table>
            </div>
            
        <!-- Customer controls !-->
        <div id="dvCustomersTitle" >CUSTOMERS</div>

        <div id="dvCustomers" style="display:none;">
            <table >
            <tr>
                <td style="border:none"><button id="btnCustomerGet" style="width: 80px">GET</button></td>
                <td style="border:none"><button id="btnCustomerPost" style="width: 80px">ADD</button></td>
                <td style="border:none"><button id="btnCustomerPut" style="width: 80px">UPDATE</button></td>
                <td style="border:none"><button id="btnCustomerDel" style="width: 80px">DELETE</button></td>
            </tr>
            </table>

        </div>

        <div id="dvCustomersDetail" style="display:none;">
            <div id="dvCustomersID" style="display:none;">
                <br />
                CustomerID: <input type="text" id="txtCustomersID" onkeydown="GetKeydown(event,'Customers')" />
                 <br /><br />
            </div>

            <div id="dvCustomersGet" style="display:none;" >
                 (To get all customers, just hit enter without specifying any customer ID)
                 <br /><br />
                <table id="CustomersDataTable">
                    <tr>
                        <th>Customer ID</th>
                        <th>EMail</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                    </tr>
                </table>
            </div>

            <div id="dvCustomersControlsAdd" style="display:none">
                <table>
                    <tr>
                        <td style="width: 50%">EMail:</td> 
                        <td style="width: 50%"><input type="text" id="txtEMail" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Password:</td> 
                        <td><input type="text" id="txtPassword" style="width: 100px" /> </td>
                    </tr>
                </table>
            </div>

            <div id="dvCustomersControls" style="display:none">
                <table>
                    <tr>
                        <td style="width: 50%">Billing Company:</td> 
                        <td style="width: 50%"><input type="text" id="txtBillCompany" style="width: 100px" /> </td>
                    </tr>
                    <tr>
                        <td>Billing First Name:</td> 
                        <td><input type="text" id="txtBillFirstName" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Billing Last Name:</td> 
                        <td><input type="text" id="txtBillLastName" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Billing Address 1:</td> 
                        <td><input type="text" id="txtBillAddress1" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Billing Address 2:</td> 
                        <td><input type="text" id="txtBillAddress2" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Billing City:</td> 
                        <td><input type="text" id="txtBillCity" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Billing State:</td> 
                        <td><input type="text" id="txtBillState" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Billing ZipCode:</td> 
                        <td><input type="text" id="txtBillZipCode" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Billing Country:</td> 
                        <td><input type="text" id="txtBillCountry" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Billing Phone:</td> 
                        <td><input type="text" id="txtBillPhone" style="width: 100px" /></td>
                    </tr>
                </table>
            </div>

            <br />

            <div id="dvCustomersAdd" style="display:none">
                <input id="btnAddCustomer" type="button" value="Add Customer"
                onclick = "AddCustomer('Customers', $('#txtCustomersID')[0].value)" /> 
                
            </div>

            <div id="dvCustomersUpdate" style="display:none">
                <input id="btnUpdateCustomer" type="button" value="Update Customer"
                onclick = "UpdateCustomer('Customers', $('#txtCustomersID')[0].value)" />

            </div>
        
            <div id="dvCustomersDEL" style="display:none;">
                <input id="btnDeleteCustomer" type="button" value="Delete Customer"
                onclick = "DeleteRecord('Customers', $('#txtCustomersID')[0].value)" />
            </div>

            <br />


    </div>



        <!-- Customer Group controls !-->
        <div id="dvCustomerGroupsTitle">CUSTOMER GROUPS</div>

        <div id="dvCustomerGroups" style="display:none;">
            <table >
            <tr>
                <td style="border:none"><button id="btnCustomerGroupGet" style="width: 80px">GET</button></td>
                <td style="border:none"><button id="btnCustomerGroupPost" style="width: 80px">ADD</button></td>
                <td style="border:none"><button id="btnCustomerGroupPut" style="width: 80px">UPDATE</button></td>
                <td style="border:none"><button id="btnCustomerGroupDel" style="width: 80px">DELETE</button></td>
            </tr>
            </table>

        </div>

        <div id="dvCustomerGroupsDetail" style="display:none;">
            
            <div id="dvCustomerGroupsID" style="display:none;">
                <br />
                GroupID: <input type="text" id="txtCustomerGroupsID" onkeydown="GetKeydown(event,'CustomerGroups')" />
                 <br /><br />
            </div>

            <div id="dvCustomerGroupsGet" style="display:none;" >
                 (To get all customer groups, just hit enter without specifying any group ID)
                 <br /><br />
                <table id="CustomerGroupsDataTable">
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Minimum Order</th>
                        <th>Registration Message</th>

                    </tr>
                </table>
            </div>

            <div id="dvCustomerGroupsControls" style="display:none">
                <table>
                    <tr>
                        <td>Name:</td> 
                        <td><input type="text" id="txtCGroupName" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Description:</td> 
                        <td><input type="text" id="txtCGroupDescription" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Minimum Order:</td> 
                        <td><input type="text" id="txtCGroupMinimumOrder" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Registration Message:</td> 
                        <td><input type="text" id="txtCGroupRegistrationMessage" style="width: 100px" /></td>
                    </tr>

                </table>
            </div>

            <br />

            <div id="dvCustomerGroupsAdd" style="display:none">
                <input id="btnAddCustomerGroup" type="button" value="Add Customer Group"
                onclick = "AddCustomerGroup('CustomerGroups', $('#txtCustomerGroupsID')[0].value)" />
            </div>

            <div id="dvCustomerGroupsUpdate" style="display:none">
                <input id="btnUpdateCustomerGroup" type="button" value="Update Customer Group"
                onclick = "UpdateCustomerGroup('CustomerGroups', $('#txtCustomerGroupsID')[0].value)" />

            </div>
        
            <div id="dvCustomerGroupsDEL" style="display:none;">
                <input id="btnDeleteCustomerGroup" type="button" value="Delete Customer Group"
                onclick = "DeleteRecord('CustomerGroups', $('#txtCustomerGroupsID')[0].value)" />
            </div>

            <br />

    </div>


        <!-- Product controls !-->
        <div id="dvProductsTitle">PRODUCTS</div>

        <div id="dvProducts" style="display:none;">
            <table >
            <tr>
                <td style="border:none"><button id="btnProductGet" style="width: 80px">GET</button></td>
                <td style="border:none"><button id="btnProductPost" style="width: 80px">ADD</button></td>
                <td style="border:none"><button id="btnProductPut" style="width: 80px">UPDATE</button></td>
                <td style="border:none"><button id="btnProductDel" style="width: 80px">DELETE</button></td>
            </tr>
            </table>

        </div>

        <div id="dvProductsDetail" style="display:none;">
            
            <div id="dvProductsID" style="display:none;">
                <br />
                Catalog ID: <input type="text" id="txtProductsID" onkeydown="GetKeydown(event,'Products')" />
                 <br /><br />
            </div>

            <div id="dvProductsGet" style="display:none;" >
                 (To get all products, just hit enter without specifying any Catalog ID)
                 <br /><br />
                <table id="ProductsDataTable">
                    <tr>
                        <th>Catalog ID</th>
                        <th>SKU</th>
                        <th>Name</th>
                        <th>Price</th>
                        <th>Cost</th>
                    </tr>
                </table>
            </div>

            <div id="dvProductsControls" style="display:none">
                <table>

                    <tr>
                        <td>SKU</td> 
                        <td><input type="text" id="txtSKU" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Name</td> 
                        <td><input type="text" id="txtSKUName" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Price:</td> 
                        <td><input type="text" id="txtSKUPrice" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Cost:</td> 
                        <td><input type="text" id="txtSKUCost" style="width: 100px" /></td>
                    </tr>

                </table>
            </div>

            <br />

            <div id="dvProductsAdd" style="display:none">
                <input id="btnAddProduct" type="button" value="Add Product"
                onclick = "AddProduct('Products', $('#txtProductsID')[0].value)" />
            </div>

            <div id="dvProductsUpdate" style="display:none">
                <input id="btnUpdateProduct" type="button" value="Update Product"
                onclick = "UpdateProduct('Products', $('#txtProductsID')[0].value)" />

            </div>
        
            <div id="dvProductsDEL" style="display:none;">
                <input id="btnDeleteProduct" type="button" value="Delete Product"
                onclick = "DeleteRecord('Products', $('#txtProductsID')[0].value)" />
            </div>

            <br />

    </div>



        <!-- Category controls !-->
        <div id="dvCategoriesTitle">CATEGORIES</div>

        <div id="dvCategories" style="display:none;">
            <table >
            <tr>
                <td style="border:none"><button id="btnCategoryGet" style="width: 80px">GET</button></td>
                <td style="border:none"><button id="btnCategoryPost" style="width: 80px">ADD</button></td>
                <td style="border:none"><button id="btnCategoryPut" style="width: 80px">UPDATE</button></td>
                <td style="border:none"><button id="btnCategoryDel" style="width: 80px">DELETE</button></td>
            </tr>
            </table>

        </div>

        <div id="dvCategoriesDetail" style="display:none;">
            
            <div id="dvCategoriesID" style="display:none;">
                <br />
                Category ID: <input type="text" id="txtCategoriesID" onkeydown="GetKeydown(event,'Categories')" />
                 <br /><br />
            </div>

            <div id="dvCategoriesGet" style="display:none;" >
                 (To get all Categories, just hit enter without specifying any Category ID)
                 <br /><br />
                <table id="CategoriesDataTable">
                    <tr>
                        <th>Category ID</th>
                        <th>Name</th>
                        <th>Description</th>
                    </tr>
                </table>
            </div>

            <div id="dvCategoriesControls" style="display:none">
                <table>

                    <tr>
                        <td>Name</td> 
                        <td><input type="text" id="txtCategoryName" style="width: 100px" /></td>
                    </tr>
                    <tr>
                        <td>Description:</td> 
                        <td><input type="text" id="txtCategoryDescription" style="width: 100px" /></td>
                    </tr>

                </table>
            </div>

            <br />

            <div id="dvCategoriesAdd" style="display:none">
                <input id="btnAddCategory" type="button" value="Add Category"
                onclick = "AddCategory('Categories', $('#txtCategoriesID')[0].value)" />
            </div>

            <div id="dvCategoriesUpdate" style="display:none">
                <input id="btnUpdateCategory" type="button" value="Update Category"
                onclick = "UpdateCategory('Categories', $('#txtCategoriesID')[0].value)" />

            </div>
        
            <div id="dvCategoriesDEL" style="display:none;">
                <input id="btnDeleteCategory" type="button" value="Delete Category"
                onclick = "DeleteRecord('Categories', $('#txtCategoriesID')[0].value)" />
            </div>

            <br />

        </div>



        <!-- Order controls !-->
        <div id="dvOrdersTitle">ORDERS</div>

        <div id="dvOrders" style="display:none;">
            <table >
            <tr>
                <td style="border:none"><button id="btnOrderGet" style="width: 80px">GET</button></td>
                <td style="border:none"><button id="btnOrderPost" style="width: 80px">ADD</button></td>
                <td style="border:none"><button id="btnOrderPut" style="width: 80px">UPDATE</button></td>
                <td style="border:none"><button id="btnOrderDel" style="width: 80px; display: none">DELETE</button></td>
                
            </tr>
            </table>

        </div>

        <div id="dvOrdersDetail" style="display:none;">
            
            <div id="dvOrdersID" style="display:none;">
                <br />
                Order ID: <input type="text" id="txtOrdersID" onkeydown="GetKeydown(event,'Orders')" />
                 <br /><br />
            </div>

            <div id="dvOrdersGet" style="display:none;" >
                 (To get all Orders, just hit enter without specifying any Order ID)
                 <br /><br />
                <table id="OrdersDataTable">
                    <tr>
                        <th>Order ID</th>
                        <th>Invoice Number Prefix</th>
                        <th>Invoice Number</th>
                        <th>Customer ID</th>
                        <th>Order Date</th>
                        <th>Order Status ID</th>
                        <th>Billing Firstname</th>
                        <th>Billing Lastname</th>
                        <th>Billing Phone</th>
                        <th>Billing Address</th>
                        <th>Billing City</th>
                        <th>Billing Country</th>
                        <th>Billing State</th>
                        <th>Billing Zip</th>
                        <th>Billing EMail</th>

                    </tr>
                </table>
            </div>

            <div id="dvOrdersControls" style="display:none">
<!--
                <table>

                    <tr>
                        <td>Invoice Number Prefix</td> 
                        <td><input type="text" id="txtInvoiceNumberPrefix" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Invoice Number:</td> 
                        <td><input type="text" id="txtInvoiceNumber" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Customer ID:</td> 
                        <td><input type="text" id="txtOrderCustomerID" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Order Date:</td> 
                        <td><input type="text" id="txtOrderDate" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Order Status ID</td> 
                        <td><input type="text" id="txtOrderStatusID" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Billing Firstname</td> 
                        <td><input type="text" id="txtOrderBillingFirstName" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Billing Lastname</td> 
                        <td><input type="text" id="txtOrderBillingLastName" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Billing Phone</td> 
                        <td><input type="text" id="txtOrderBillingPhone" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Billing Address</td> 
                        <td><input type="text" id="txtOrderBillingAddress" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Billing City</td> 
                        <td><input type="text" id="txtOrderBillingCity" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Billing Country</td> 
                        <td><input type="text" id="txtOrderBillingCountry" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Billing State</td> 
                        <td><input type="text" id="txtOrderBillingState" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Billing Zip</td> 
                        <td><input type="text" id="txtOrderBillingZip" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Billing EMail</td> 
                        <td><input type="text" id="txtOrderBillingEMail" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Shipment Firstname</td> 
                        <td><input type="text" id="txtOrderShipmentFirstName" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Shipment Lastname</td> 
                        <td><input type="text" id="txtOrderShipmentLastName" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Shipment Phone</td> 
                        <td><input type="text" id="txtOrderShipmentPhone" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Shipment Address</td> 
                        <td><input type="text" id="txtOrderShipmentAddress" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Shipment City</td> 
                        <td><input type="text" id="txtOrderShipmentCity" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Shipment Country</td> 
                        <td><input type="text" id="txtOrderShipmentCountry" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Shipment State</td> 
                        <td><input type="text" id="txtOrderShipmentState" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Shipment Zip</td> 
                        <td><input type="text" id="txtOrderShipmentZip" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Shipment EMail</td> 
                        <td><input type="text" id="txtOrderShipmentEMail" style="width: 100px" /></td>
                    </tr>

                </table>

                !-->
                <span><br />
                    Due to the complexity of the order object, it is not possible to provide one sample JSON object that will work in all stores. 
                    The JSON object below contains sample values that would need to be changed in order to match the values in your store's database. 
                    Below is a list of values that must match: 
                    <br /><br />
                    For ADD, Invoice Number and OrderID doesn't need to be specified in JSON.
                    <br />
                    For UPDATE, OrderID needs to be specified in OrderID text box and in JSON.
                    <br /><br />
                    'Required fields for Order<br />
                    'Billing Information<br />
                    <br />
                    Billing First Name<br />
                    Billing Last Name<br />
                    Billing Address<br />
                    Billing City<br />
                    Billing Country<br />
                    Billing Phone Number<br />
                    <br />
                    'For Amazon Import<br />
                    Billing State<br />
                    Billing ZipCode<br />
                    <br />
                    'ShipmentList should have at least one Shipment<br /> 
                    'For Non Amazon Import<br />
                    Shipment First Name<br />
                    Shipment Last Name<br />
                    Shipment Address<br />
                    Shipment City<br />
                    Shipment Country<br />
                    Shipment Phone<br />
                    <br />
                    'If Shipment Country is US<br />
                    Shipment State<br />
                    Shipment ZipCode<br />
                    <br />
                    An Order should have a valid Customer and Customer should have an email.<br />
                    OrderItemList should have at least one item.<br />
                    An OrderItem should have a valild CatalogID.<br />
                    TransactionList is not required. However, if there is a TransactionList, TransactionGatewayID should be valid.<br />
                    QuestionList is not required. However, if there is a QuestionList, QuestionID should be valid.<br />
                    OrderStatusID should be valid.<br />
                    There should be a valid Online/Offline payment method ID on the Order.<br /><br />
                </span>
                <textarea id="txtOrderJson" cols="200" rows="40">
{
  "InvoiceNumberPrefix": "sample string 1",
  "InvoiceNumber": 3,
  "OrderID": 3,
  "CustomerID": 3,
  "OrderDate": "2016-01-26T15:54:24.888551-05:00",
  "OrderStatusID": 1,
  "LastUpdate": "2016-01-26T15:54:24.888551-05:00",
  "UserID": "sample string 2",
  "SalesPerson": "sample string 3",
  "ContinueURL": "sample string 4",
  "BillingFirstName": "sample string 5",
  "BillingLastName": "sample string 6",
  "BillingCompany": "sample string 7",
  "BillingAddress": "sample string 8",
  "BillingAddress2": "sample string 9",
  "BillingCity": "sample string 10",
  "BillingState": "sample string 11",
  "BillingZipCode": "sample string 12",
  "BillingCountry": "sample string 13",
  "BillingPhoneNumber": "sample string 14",
  "BillingEmail": "sample string 15",
  "BillingPaymentMethod": "stripe",
  "BillingOnLinePayment": true,
  "BillingPaymentMethodID": "1",
  "ShipmentList": [
    {
      "ShipmentID": 1,
      "ShipmentLastUpdate": "2016-01-26T15:54:24.888551-05:00",
      "ShipmentBoxes": 1,
      "ShipmentInternalComment": "sample string 1",
      "ShipmentOrderStatus": 1,
      "ShipmentAddress": "sample string 2",
      "ShipmentAddress2": "sample string 3",
      "ShipmentAlias": "sample string 4",
      "ShipmentCity": "sample string 5",
      "ShipmentCompany": "sample string 6",
      "ShipmentCost": 1.1,
      "ShipmentCountry": "sample string 7",
      "ShipmentEmail": "sample string 8",
      "ShipmentFirstName": "sample string 9",
      "ShipmentLastName": "sample string 10",
      "ShipmentMethodID": 1,
      "ShipmentMethodName": "sample string 11",
      "ShipmentShippedDate": "sample string 12",
      "ShipmentPhone": "sample string 13",
      "ShipmentState": "sample string 14",
      "ShipmentZipCode": "sample string 15",
      "ShipmentTax": 1.1,
      "ShipmentWeight": 1.1,
      "ShipmentTrackingCode": "sample string 16",
      "ShipmentUserID": "sample string 17",
      "ShipmentNumber": 1,
      "ShipmentAddressTypeID": 1
    },
    {
      "ShipmentID": 1,
      "ShipmentLastUpdate": "2016-01-26T15:54:24.888551-05:00",
      "ShipmentBoxes": 1,
      "ShipmentInternalComment": "sample string 1",
      "ShipmentOrderStatus": 1,
      "ShipmentAddress": "sample string 2",
      "ShipmentAddress2": "sample string 3",
      "ShipmentAlias": "sample string 4",
      "ShipmentCity": "sample string 5",
      "ShipmentCompany": "sample string 6",
      "ShipmentCost": 1.1,
      "ShipmentCountry": "sample string 7",
      "ShipmentEmail": "sample string 8",
      "ShipmentFirstName": "sample string 9",
      "ShipmentLastName": "sample string 10",
      "ShipmentMethodID": 1,
      "ShipmentMethodName": "sample string 11",
      "ShipmentShippedDate": "sample string 12",
      "ShipmentPhone": "sample string 13",
      "ShipmentState": "sample string 14",
      "ShipmentZipCode": "sample string 15",
      "ShipmentTax": 1.1,
      "ShipmentWeight": 1.1,
      "ShipmentTrackingCode": "sample string 16",
      "ShipmentUserID": "sample string 17",
      "ShipmentNumber": 1,
      "ShipmentAddressTypeID": 1
    }
  ],
  "OrderItemList": [
    {
      "CatalogID": 1,
      "ItemIndexID": 1,
      "ItemID": "sample string 1",
      "ItemShipmentID": 1,
      "ItemQuantity": 1.1,
      "ItemWarehouseID": 1,
      "ItemDescription": "sample string 2",
      "ItemUnitPrice": 1.1,
      "ItemWeight": 1.1,
      "ItemOptionPrice": 1.1,
      "ItemAdditionalField1": "sample string 3",
      "ItemAdditionalField2": "sample string 4",
      "ItemAdditionalField3": "sample string 5",
      "ItemPageAdded": "sample string 6",
      "ItemDateAdded": "2016-01-26T15:54:24.888551-05:00",
      "ItemUnitCost": 1.1,
      "ItemUnitStock": 1,
      "ItemOptions": "sample string 7",
      "ItemCatalogIDOptions": "sample string 8"
    },
    {
      "CatalogID": 1,
      "ItemIndexID": 1,
      "ItemID": "sample string 1",
      "ItemShipmentID": 1,
      "ItemQuantity": 1.1,
      "ItemWarehouseID": 1,
      "ItemDescription": "sample string 2",
      "ItemUnitPrice": 1.1,
      "ItemWeight": 1.1,
      "ItemOptionPrice": 1.1,
      "ItemAdditionalField1": "sample string 3",
      "ItemAdditionalField2": "sample string 4",
      "ItemAdditionalField3": "sample string 5",
      "ItemPageAdded": "sample string 6",
      "ItemDateAdded": "2016-01-26T15:54:24.888551-05:00",
      "ItemUnitCost": 1.1,
      "ItemUnitStock": 1,
      "ItemOptions": "sample string 7",
      "ItemCatalogIDOptions": "sample string 8"
    }
  ],
  "OrderDiscount": 1.1,
  "SalesTax": 1.1,
  "SalesTax2": 1.1,
  "SalesTax3": 1.1,
  "OrderAmount": 1.1,
  "AffiliateCommission": 1.1,
  "TransactionList": [
    {
      "TransactionIndexID": 1,
      "OrderID": 1,
      "TransactionID": "sample string 1",
      "TransactionDateTime": "2016-01-26T15:54:24.888551-05:00",
      "TransactionType": "sample string 3",
      "TransactionMethod": "sample string 4",
      "TransactionAmount": 1.1,
      "TransactionApproval": "sample string 5",
      "TransactionReference": "sample string 6",
      "TransactionGatewayID": 1,
      "TransactionCVV2": "sample string 7",
      "TransactionAVS": "sample string 8",
      "TransactionResponseText": "sample string 9",
      "TransactionResponseCode": "sample string 10",
      "TransactionCaptured": 1
    },
    {
      "TransactionIndexID": 1,
      "OrderID": 1,
      "TransactionID": "sample string 1",
      "TransactionDateTime": "2016-01-26T15:54:24.888551-05:00",
      "TransactionType": "sample string 3",
      "TransactionMethod": "sample string 4",
      "TransactionAmount": 1.1,
      "TransactionApproval": "sample string 5",
      "TransactionReference": "sample string 6",
      "TransactionGatewayID": 1,
      "TransactionCVV2": "sample string 7",
      "TransactionAVS": "sample string 8",
      "TransactionResponseText": "sample string 9",
      "TransactionResponseCode": "sample string 10",
      "TransactionCaptured": 1
    }
  ],

  "CardType": "sample string 18",
  "CardNumber": "sample string 19",
  "CardName": "sample string 20",
  "CardExpirationMonth": "sample string 21",
  "CardExpirationYear": "sample string 22",
  "CardIssueNumber": "sample string 23",
  "CardStartMonth": "sample string 24",
  "CardStartYear": "sample string 25",
  "CardAddress": "sample string 26",
  "CardVerification": "sample string 27",
  "RewardPoints": "sample string 28",

  "Referer": "sample string 29",
  "IP": "sample string 30",
  "CustomerComments": "sample string 31",
  "InternalComments": "sample string 32",
  "ExternalComments": "sample string 33"
}

</textarea>
                
            </div>

            <br />

            <div id="dvOrdersAdd" style="display:none">
                <input id="btnAddOrder" type="button" value="Add Order"
                onclick = "AddOrder('Orders', $('#txtOrdersID')[0].value)" />
            </div>

            <div id="dvOrdersUpdate" style="display:none">
                <input id="btnUpdateOrder" type="button" value="Update Order"
                onclick = "UpdateOrder('Orders', $('#txtOrdersID')[0].value)" />

            </div>
        
            <div id="dvHideOrderButton" style="display:none;">
                <div id="dvOrdersDEL" style="display:none;">
                    <input id="btnDeleteOrder" type="button" value="Delete Order"
                    onclick = "DeleteRecord('Orders', $('#txtOrdersID')[0].value)" />
                </div>
            </div>

            <br />

        </div>



        <!-- Manufacturer controls !-->
        <div id="dvManufacturersTitle">MANUFACTURERS</div>

        <div id="dvManufacturers" style="display:none;">
            <table >
            <tr>
                <td style="border:none"><button id="btnManufacturerGet" style="width: 80px">GET</button></td>
                <td style="border:none"><button id="btnManufacturerPost" style="width: 80px">ADD</button></td>
                <td style="border:none"><button id="btnManufacturerPut" style="width: 80px">UPDATE</button></td>
                <td style="border:none"><button id="btnManufacturerDel" style="width: 80px">DELETE</button></td>
            </tr>
            </table>

        </div>

        <div id="dvManufacturersDetail" style="display:none;">
            
            <div id="dvManufacturersID" style="display:none;">
                <br />
                Manufacturer ID: <input type="text" id="txtManufacturersID" onkeydown="GetKeydown(event,'Manufacturers')" />
                 <br /><br />
            </div>

            <div id="dvManufacturersGet" style="display:none;" >
                 (To get all Manufacturers, just hit enter without specifying any Manufacturer ID)
                 <br /><br />
                <table id="ManufacturersDataTable">
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Web Site</th>
                        <th>Page Title</th>

                    </tr>
                </table>
            </div>

            <div id="dvManufacturersControls" style="display:none">
                <table>

                    <tr>
                        <td>Name:</td> 
                        <td><input type="text" id="txtManufacturerName" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Web Site:</td> 
                        <td><input type="text" id="txtManufacturerWebsite" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Page Title:</td> 
                        <td><input type="text" id="txtManufacturerPageTitle" style="width: 100px" /></td>
                    </tr>


                </table>
            </div>

            <br />

            <div id="dvManufacturersAdd" style="display:none">
                <input id="btnAddManufacturer" type="button" value="Add Manufacturer"
                onclick = "AddManufacturer('Manufacturers', $('#txtManufacturersID')[0].value)" />
            </div>

            <div id="dvManufacturersUpdate" style="display:none">
                <input id="btnUpdateManufacturer" type="button" value="Update Manufacturer"
                onclick = "UpdateManufacturer('Manufacturers', $('#txtManufacturersID')[0].value)" />
            </div>
        
            <div id="dvManufacturersDEL" style="display:none;">
                <input id="btnDeleteManufacturer" type="button" value="Delete Manufacturer"
                onclick = "DeleteRecord('Manufacturers', $('#txtManufacturersID')[0].value)" />
            </div>

            <br />

        </div>


            <!-- Distributor controls !-->
        <div id="dvDistributorsTitle">DISTRIBUTORS</div>

        <div id="dvDistributors" style="display:none;">
            <table >
            <tr>
                <td style="border:none"><button id="btnDistributorGet" style="width: 80px">GET</button></td>
                <td style="border:none"><button id="btnDistributorPost" style="width: 80px">ADD</button></td>
                <td style="border:none"><button id="btnDistributorPut" style="width: 80px">UPDATE</button></td>
                <td style="border:none"><button id="btnDistributorDel" style="width: 80px">DELETE</button></td>
            </tr>
            </table>

        </div>

        <div id="dvDistributorsDetail" style="display:none;">
            
            <div id="dvDistributorsID" style="display:none;">
                <br />
                Distributor ID: <input type="text" id="txtDistributorsID" onkeydown="GetKeydown(event,'Distributors')" />
                 <br /><br />
            </div>

            <div id="dvDistributorsGet" style="display:none;" >
                 (To get all Distributors, just hit enter without specifying any Distributor ID)
                 <br /><br />
                <table id="DistributorsDataTable">
                    <tr>
                        <th>ID</th>
                        <th>Company Name</th>
                        <th>Contact Name</th>
                        <th>Address</th>
                        <th>City</th>
                        <th>State</th>

                    </tr>
                </table>
            </div>

            <div id="dvDistributorsControls" style="display:none">
                <table>

                    <tr>
                        <td>Company Name:</td> 
                        <td><input type="text" id="txtDistributorCompanyName" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Contact Name:</td> 
                        <td><input type="text" id="txtDistributorContactName" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>Address:</td> 
                        <td><input type="text" id="txtDistributorAddress" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>City:</td> 
                        <td><input type="text" id="txtDistributorCity" style="width: 100px" /></td>
                    </tr>

                    <tr>
                        <td>State:</td> 
                        <td><input type="text" id="txtDistributorState" style="width: 100px" /></td>
                    </tr>


                </table>
            </div>

            <br />

            <div id="dvDistributorsAdd" style="display:none">
                <input id="btnAddDistributor" type="button" value="Add Distributor"
                onclick = "AddDistributor('Distributors', $('#txtDistributorsID')[0].value)" />
            </div>

            <div id="dvDistributorsUpdate" style="display:none">
                <input id="btnUpdateDistributor" type="button" value="Update Distributor"
                onclick = "UpdateDistributor('Distributors', $('#txtDistributorsID')[0].value)" />
            </div>
        
            <div id="dvDistributorsDEL" style="display:none;">
                <input id="btnDeleteDistributor" type="button" value="Delete Distributor"
                onclick = "DeleteRecord('Distributors', $('#txtDistributorsID')[0].value)" />
            </div>

            <br />

        </div>



</body>
</html>

