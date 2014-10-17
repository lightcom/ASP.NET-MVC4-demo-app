ASP.NET-MVC4-demo-app
=====================

This is a simple ASP.NET MVC 4 demo application that I prepared for an interview.

The requirements I was given:

1. Application should work as a guest book of a website. Users should be able leave messages and also it should be possible to review all messages in a list.
2. A message form should contain User Name, Email, Homepage (as not required), CAPTCHA and Text.
3. Application should save entered data and also save user's IP and Web-browser, and systime.
4. All messages should be showed in a table with sorting capability (default sorting LIFO by systime) and paging (25 pages).
5. Application should be build with security in mind (against XSS-attack and SQL-injection).
6. Should be used ASP.NET MVC and Entity Framework.

For implementing CAPTCHA I used CaptchaMvc.



