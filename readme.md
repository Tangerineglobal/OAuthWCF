# WCF using OAuth2 authentication

## Overview
This is a rare opportunity to get paid to code an open-source code sample that will help other developers. Payment will be given upon development completion. All code will then be posted on CodePlex under the The "New" BSD License and all recognition will go the developer. The developer will not be required to post to CodePlex, maintain the codebase, nor respond to issues on the CodePlex project, but can do so if they desire. If not, we will handle all of the CodePlex portion of this project.
 
## Scenario
You are tasked with exposing a web service to third parties. You would like to support as many different client types and methods as possible. Authentication is needed. OAuth2 is desired over OAuth1 and SAML because of its simplicity and wide support for a variety of clients. WCF is desired because of its simplicity in exposing both JSON REST and SOAP endpoints.
 
## Requirements:
1. Create a WCF Web Service which exposes 2 .svc files, each containing 1 method, with both JSON REST and SOAP endpoints:
  1. UserAdmin.svc - accessible only by TokenIssuer role
     - POST RegisterUser(string name, string role, string emailaddress) returns string Token
  2. Service.svc - accessible by TokenIssuer and AppUser roles
     - GET GetEmail() returns string emailaddress
  3. SOAP and JSON REST endpoints should be exposed via the endpointBehaviors in the web.config
  4. Assume modern IIS hosting and set up the web.config accordingly
  5. Store necessary data in IIS Express LocalDB with the ConnectionString being configurable in the web.config

2. Secure both .svc using OAuth2
  1. You are encouraged to use either DotNetOpenAuth or Thinktecture IdentityServer
  2. Will accept and authenticate using querystring variables (ex: http://site.com/Service.svc/json/GetEmail?client_id=oegtutaXFy8LceH86DI9b&client_secret=REpqmKWN9fn9N0GOxMPwgbFErOTJvh7Fnj5ucgq1)
  3. The authentication should not be part of the logic in the .svc methods, but should take place in the ServiceAuthorizationManager
  4. Claims (such as emailaddress) and Roles should be accessible using standard Principle methods