<b><font size="6">3dCart Rest API OAuth Client</font></b>
<br><br>
Our latest SDK includes our OAuth 2 examples.

To generate the authorize URL, use this code:

ThreeDCartOAuthProvider authProvider = new ThreeDCartOAuthProvider();
string url = authProvider.GetAuthorizeUrl(clientId, redirectUrl, secureUrl);
					
Once you receive the authorization code, you may obtain an access token:
					
	public ActionResult ThreeDCartAuthCallBack(string code)
	{
		string clientId = "Enter client Id";
		string clientSecret = "Enter client secret";
		string redirectUrl = "Enter redirect Url";

		ThreeDCartOAuthProvider authProvider = new ThreeDCartOAuthProvider();

		ThreeDCartAuth auth = authProvider.GetAccessToken(redirectUrl, clientId, code, clientSecret);
	}

To call the API, use this code:
		
	string clientId = "Enter client Id";
	string clientSecret = "Enter client secret";
	string secureUrl = "Enter secure Url";

	ThreeDCartProvider provider = new ThreeDCartProvider(clientSecret, password, secureUrl);
	provider.SearchOrders(DateTime.Now.AddDays(-1), DateTime.Now, "New");

<br><br>
<b><font size="6">3dCart Rest API Client</font></b>
<br><br>
The 3DCart REST API can be used to retrieve data and/or make changes to a clients store. The information regarding the 3dCart REST API can be found at the link below:
<br><br>
https://apirest.3dcart.com/
<br><br>

3dCart Rest API Client for C# is a project that explains how to use the 3dCart Rest API. The purpose of this project is to provide an example to 3dCart clients for how one might use 3dCart Rest API in their custom applications.
<br><br>
This 3dCart Rest API Client is a C# solution that has two projects
<br><ul>
     <li>1.	3dCartRestAPIClient
<br>
     <li>2.	RestAPIClientInterface
</ul>
 The following is a brief explanation of each of these projects:
<br><br>
<b><font size="4">3dCartRestAPIClient Project:</font></b>
<br><p>
This project uses the 3dCart Rest API to perform basic operations like SELECT, INSERT, UPDATE and DELETE on a clients store. In order to perform these operations, we have functions that use HTTP GET, POST, PUT and DELETE commands. We will be using the following 3dCart objects in this project to perform these operations.</p><ul>
<li>Customer
<li>CustomerGroup
<li>Category
<li>Product
<li>Order
<li>Manufacturer
<li>Distributor
</ul>
<p>For each object, a class is defined that shows attributes of the object as class properties. Instances of the classes will be used to store data.
<br><br>
Along with the above classes, there are a few other classes in the project; these are explained as follows:</p>

<font size="4"><b>RestAPIActions.cs</b></font>
<br>
<p>This is the core class which has functions to perform the HTTP GET, POST, PUT and DELETE operations.  It has the following properties and functions:</p>


<font size="4"><b>Properties:</b></font>
<br>
<ul>
<li><b>HttpHost:</b> Holds the http Host name. For example. http://apirest.3dcart.com/3dCartWebAPI/v
<li><b>ServiceVersion:</b> Holds the service version. For example 1.
<li><b>PrivateKey:</b> Holds the private key to connect to the store. 
<li><b>Token:</b> Holds the token to connect to the store.
<li><b>SecureURL:</b> Holds the secure URL of the store. For Example, 3dcart-nadeem-com.3dcartstores.com
<li><b>ContentType:</b> Holds the content type, which is only JSON for now. For example, application/json
<li><b>ID:</b> Holds the ID of the record, if required.
<li><b>Type:</b>  Holds the type of Rest API object. For example, Customers, CustomerGroups
<li><b>RecordsGetLimit:</b> Holds the value for the maximum that can be retrieved through a GET operation.
 </ul><br>
<font size="4"><b>Methods:</b></font><br>
<ul>
<li><b>GetClient:</b> Provides a connection to the Rest API URL.
<li><b>GetRecords:</b> Retrieves records using HTTP GET.
<li><b>AddRecord:</b> Adds a record using HTTP POST.
<li><b>UpdateRecord:</b> Updates a record using HTTP PUT.
<li><b>DeleteRecord:</b> Deletes a record using HTTP DELETE.
</ul><br>
<font size="4"><b>RecordInfo.cs:</b></font>
<p>This class stores the HTTP response values in properties; examples include but are not limited to: </p>
<ul>
<li><b>Status:</b> Indicates if the HTTP operation succeeded or failed.
<li><b>Code Number:</b> Holds the code returned as a result of the HTTP operation.
<li><b>Description:</b> Holds the description/message from a response. This can be an error message due to an invalid operation.
<li><b>ResultSet:</b> Stores data as an Object. For GET operations, it may stores a whole result set and for other operations, it may store just the record id.
</ul>

<font size="4"><b>ResponseInfo.cs:</b></font>
<p>This class holds the de-serialized response from an HTTP response stream and has the following properties.</p>
<ul>
<li><b>Key:</b> stores the key 
<li><b>Value:</b> Stores the value for the key.
<li><b>Status:</b> stores the status of the HTTP operation.
<li><b>Message:</b> Stores any messages yielded from the response.
</ul>

<font size="5"><b>RestAPIClientInterface Project:</b></font>
<p>This ASP.NET project is designed to create an interface for the 3dCart Rest API Client and allows a user to SELECT, INSERT, UPDATE and DELETE records for the following rest API types.</p>
<ul>
<li>Customer
<li>CustomerGroup
<li>Category
<li>Product
<li>Order
<li>Manufacturer
<li>Distributor
</ul><p>
The project is a single page and has two core files:</p>
<br>
<br>
<font size="5"><b>Main.aspx.cs:</b></font>
<p>
This code behind the file has WebMethod; which calls the Rest API Client functions to perform SELECT, INSERT, UPDATE and DELETE operations.
<br><br>
<b>GetRestAPIRecords:</b> Retrieves the records for a specific Rest API Type (Customer, Order etc.). This function requires PrivateKey, Token and SecureURL parameters to connect to a client store, while RestAPIType and strRestAPIID contain the REST API Type and ID of the record (if no ID is specified, records within the RecordsGetLimit will be retrieved).
<br><br>
<b>AddRecord:</b> Adds a record for a specific Rest API Type. PrivateKey, Token and SecureURL parameters are required to connect to a client store, while the RestAPIObject parameter carries the object to be added.
<br><br>
<b>UpdateRecord:</b> Updates a record for a specific Rest API Type. PrivateKey, Token and SecureURL parameters are required to connect to a client store, while RestAPIObject carries the object to be updated and RestAPIUpdateID holds the ID of the object to be updated.
<br><br>
<b>DeleteRecord:</b> Deletes a record for a specific Rest API Type. PrivateKey, Token and SecureURL parameters are required to connect to a client store, while RestAPIDeleteID holds the ID of the object to be deleted.
<br><br></p>
<font size="5"><b>Main.aspx:</b></font>
<p>This front end page has HTML, JavaScript and JQuery to create the main form. </p>
<b>HTML:</b> For drawing DIVs, text boxes, labels and tables
<br><br>
<b>Javascript/JQuery:</b> Uses AJAX Jquery calls to call the Webmethods in the code to perform Get, Add, Update and Delete operations. These calls are asynchronous and retrieve data without refreshing the page. 
