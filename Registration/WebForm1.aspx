<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Registration.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <script>
       function showToast(type, message) {
           var toastContainer = document.getElementById("toast-container");
           var toast = document.createElement("div");
           toast.className = "toast " + type;
           toast.innerHTML = message;
           toastContainer.appendChild(toast);

           setTimeout(function () {
               toast.remove();
           }, 3000); // Adjust the timeout (in milliseconds) as needed
       }
   </script>
 
    <title>Registration Form</title>
    <style>
      
         #toast-container {
        position: fixed;
        top: 20px;
        right: 20px;
        max-width: 300px;
        z-index: 1000; /* Ensure it appears above other elements */
    }

    .toast {
        background-color: #4CAF50; /* Green for success */
        color: white;
        padding: 15px;
        margin-bottom: 10px;
        border-radius: 5px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }

    .error {
        background-color: #f44336; /* Red for error */
    }

        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 0;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        #form1 {
            max-width: 400px;
            background-color: #FDF7E4;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            transition: box-shadow 0.3s ease;
        }

        #form1:hover {
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.2);
        }

        div {
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin-bottom: 8px;
            color: #495057;
            
        }

        .text-box {
            width: calc(100% - 22px);
            padding: 10px;
            box-sizing: border-box;
            border: 1px solid #ced4da;
            border-radius: 4px;
            transition: border-color 0.3s ease;
        }

        .text-box:focus {
            border-color: #007bff;
        }

        .Button-div{
            text-align: center;
        }
        .Button {
            
            background-color: #7B66FF;
            color: #fff;
            padding: 10px 20px;
            border: 1px solid #7B66FF;
            border-radius: 10px;
            cursor: pointer;
            transition: background-color 0.3s ease;
           
        }

        .Button:hover {
            background-color: white;
            color:#7B66FF
        }

        .error-message {
            color: #dc3545;
            margin-top: 5px;
        }
    </style>
</head>
<body>
    <div id="toast-container"></div>
    <form id="form1" runat="server">
        <h2>Student Registration Form!</h2>
        <div>
            <label for="FullName">Full Name</label>
            <asp:TextBox class="text-box" ID="FullName" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="Eid">Employee ID</label>
            <asp:TextBox class="text-box" ID="Eid" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="Dept">Department</label>
            <asp:TextBox class="text-box" ID="Dept" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="mail">Email ID</label>
            <asp:TextBox class="text-box" ID="mail" runat="server"></asp:TextBox>
           
        </div>
        <div class="Button-div">
            <asp:Button class="Button" ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        </div>
    </form>
     

    
     
</body>
</html>
