# Login Middleware for ASP.NET Core

The **LoginMiddleware** is an ASP.NET Core middleware designed to handle login requests by validating user credentials. It extracts email and password information from the incoming request and checks if they match a predefined set of credentials. The middleware responds with appropriate HTTP status codes and messages based on the validation results.

## Table of Contents
- [Usage](#usage)
- [Middleware Overview](#middleware-overview)
- [Examples](#examples)

---

## Usage
The LoginMiddleware is designed to handle login requests at the root path ("/") using the HTTP POST method. It expects email and password parameters in the request body and validates them against predefined credentials.

---

## Middleware Overview

LoginMiddleware
The core middleware class that handles login requests. It performs the following tasks:

- Reads the request body and extracts email and password information.
- Validates the presence of both email and password.
- Validates the provided credentials against predefined values.
- Responds with appropriate HTTP status codes and messages.
- MiddlewareExtensions
- Extension methods to add the LoginMiddleware to the ASP.NET Core application's request pipeline.

---

## Examples

Valid Login Request
http
Copy code
POST / HTTP/1.1
Host: example.com
Content-Type: application/x-www-form-urlencoded

email=admin@example.com&password=admin1234
Response:

http
Copy code
HTTP/1.1 200 OK
Content-Length: 26

Login Successful! 200 OK
Invalid Login Request
http
Copy code
POST / HTTP/1.1
Host: example.com
Content-Type: application/x-www-form-urlencoded

email=user@example.com&password=invalid
Response:

http
Copy code
HTTP/1.1 400 Bad Request
Content-Length: 29

Login Failed! 400 Bad Request
Contributing
Contributions are welcome! Please follow the Contributing Guidelines when submitting issues or pull requests.
