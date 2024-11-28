# Aegiss  

Aegiss is a Web API built with C# designed for secure access creation and credential management, focusing on security and seamless frontend integration.  

## Key Features  

- **Access Creation**: Endpoints to register users and set up credentials.  
- **Credential Recovery**: Secure system for password and credential recovery.  
- **Password Validation**: Ensures strong and secure passwords.  
- **Secure Authentication**:  
  - **JWT Token**: For access authentication and authorization.  
  - **Google Authenticator**: Two-factor authentication (2FA) for enhanced security.  
- **Advanced Encryption**:  
  - **Argon2**: For encrypting user passwords, ensuring maximum resistance to brute force attacks.  
  - **AES Encryption Service**: To securely encrypt and decrypt stored credentials.  

## Technologies Used  

- **ASP.NET Core**: Framework for building the Web API.  
- **Entity Framework Core**: Database management.  
- **JWT (JSON Web Token)**: Authentication and authorization implementation.  
- **Google Authenticator**: For two-factor authentication (2FA).  
- **Argon2**: User password encryption.  
- **AES Encryption**: For handling sensitive data with bidirectional encryption.  
- **Validator**: Password security criteria validation.  

## Prerequisites  

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)  
- A SQL Server database or another configured database.  
- Development tools such as Visual Studio or Visual Studio Code.  


| Method  | Endpoint                           | Description                                                           |
|---------|------------------------------------|-----------------------------------------------------------------------|
| POST    | /api/Auth                          | Authenticates new users.                                              |
| GET     | /api/AuthenticatorTfa/generateqr   | Generates qr for Google Authenticator based on e-mail.                |
| POST    | /api/AuthenticatorTfa/validatecode | Validates key and code (Google Auth).                                 |
| POST    | /api/Users                         | Creates a new user for the application.                               |
| POST    | /api/LocationAccess                | Creates a new location for the credentials (ie. site).                |
| GET     | /api/LocationAccess                | Retrieves the location for the credentials (By Id and User Id).       |
| GET     | /api/LocationAccess/{appUserId}    | Retrieves all the location for the user (By User Id).                 |
| POST    | /api/CredentialEntry               | Creates the credentials for a location.                               |
| GET     | /api/CredentialEntry               | Retrieves the credentials for a location (By Location Id and User Id).|