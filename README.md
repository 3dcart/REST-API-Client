3dCart Rest API Client
The 3DCart REST API can be used to retrieve data and/or make changes to a clients store. The information regarding the 3dCart REST API can be found at the link below:
https://apirest.3dcart.com/
3dCart Rest API Client for C# is a project that explains how to use the 3dCart Rest API. The purpose of this project is to provide an example to 3dCart clients for how one might use 3dCart Rest API in their custom applications.
This 3dCart Rest API Client is a C# solution that has two projects
1.	3dCartRestAPIClient
2.	RestAPIClientInterface

 The following is a brief explanation of each of these projects:

3dCartRestAPIClient Project:
This project uses the 3dCart Rest API to perform basic operations like SELECT, INSERT, UPDATE and DELETE on a clients store. In order to perform these operations, we have functions that use HTTP GET, POST, PUT and DELETE commands. We will be using the following 3dCart objects in this project to perform these operations.
•	Customer
•	CustomerGroup
•	Category
•	Product
•	Order
•	Manufacturer
•	Distributor
For each object, a class is defined that shows attributes of the object as class properties. Instances of the classes will be used to store data.
Along with the above classes, there are a few other classes in the project; these are explained as follows:

RestAPIActions.cs
This is the core class which has functions to perform the HTTP GET, POST, PUT and DELETE operations.  It has the following properties and functions:


Properties:
HttpHost: Holds the http Host name. For example. http://apirest.3dcart.com/3dCartWebAPI/v
ServiceVersion: Holds the service version. For example 1.
PrivateKey: Holds the private key to connect to the store. 
Token: Holds the token to connect to the store.
SecureURL: Holds the secure URL of the store. For Example, 3dcart-nadeem-com.3dcartstores.com
ContentType: Holds the content type, which is only JSON for now. For example, application/json
ID: Holds the ID of the record, if required.
Type:  Holds the type of Rest API object. For example, Customers, CustomerGroups
RecordsGetLimit: Holds the value for the maximum that can be retrieved through a GET operation.
 
Methods:
GetClient: Provides a connection to the Rest API URL.
GetRecords: Retrieves records using HTTP GET.
AddRecord: Adds a record using HTTP POST.
UpdateRecord: Updates a record using HTTP PUT.
DeleteRecord: Deletes a record using HTTP DELETE.

RecordInfo.cs:
This class stores the HTTP response values in properties; examples include but are not limited to: 
Status: Indicates if the HTTP operation succeeded or failed.
Code Number: Holds the code returned as a result of the HTTP operation.
Description: Holds the description/message from a response. This can be an error message due to an invalid operation.
ResultSet: Stores data as an Object. For GET operations, it may stores a whole result set and for other operations, it may store just the record id.


ResponseInfo.cs:
This class holds the de-serialized response from an HTTP response stream and has the following properties.
Key: stores the key 
Value: Stores the value for the key.
Status: stores the status of the HTTP operation.
Message: Stores any messages yielded from the response.

RestAPIClientInterface Project:
This ASP.NET project is designed to create an interface for the 3dCart Rest API Client and allows a user to SELECT, INSERT, UPDATE and DELETE records for the following rest API types.
•	Customer
•	CustomerGroup
•	Category
•	Product
•	Order
•	Manufacturer
•	Distributor
The project is a single page and has two core files:

Main.aspx.cs:
This code behind the file has WebMethod; which calls the Rest API Client functions to perform SELECT, INSERT, UPDATE and DELETE operations. 
GetRestAPIRecords: Retrieves the records for a specific Rest API Type (Customer, Order etc.). This function requires PrivateKey, Token and SecureURL parameters to connect to a client store, while RestAPIType and strRestAPIID contain the REST API Type and ID of the record (if no ID is specified, records within the RecordsGetLimit will be retrieved).
AddRecord: Adds a record for a specific Rest API Type. PrivateKey, Token and SecureURL parameters are required to connect to a client store, while the RestAPIObject parameter carries the object to be added.
UpdateRecord: Updates a record for a specific Rest API Type. PrivateKey, Token and SecureURL parameters are required to connect to a client store, while RestAPIObject carries the object to be updated and RestAPIUpdateID holds the ID of the object to be updated.
DeleteRecord: Deletes a record for a specific Rest API Type. PrivateKey, Token and SecureURL parameters are required to connect to a client store, while RestAPIDeleteID holds the ID of the object to be deleted.

Main.aspx:
This front end page has HTML, JavaScript and JQuery to create the main form. 
HTML: For drawing DIVs, text boxes, labels and tables
Javascript/JQuery: Uses AJAX Jquery calls to call the Webmethods in the code to perform Get, Add, Update and Delete operations. These calls are asynchronous and retrieve data without refreshing the page. 
