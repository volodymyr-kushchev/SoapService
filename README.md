# SoapService
Simple ASP.NEt Core WebAPI project with SOAP endpoint

# How to call it from postman
URL: https://localhost:7180/SoapService.asmx <br />
Method: Post <br />
Body Type: XML <br />
Body: <br />
```xml
<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/">
   <soapenv:Header/>
   <soapenv:Body>
      <GetBinaryRepresentation xmlns="https://localhost:7180/">
         <inputValue>101</inputValue>
      </GetBinaryRepresentation>
   </soapenv:Body>
</soapenv:Envelope>
```

![image](https://github.com/user-attachments/assets/25041f76-6e69-4c27-8792-80ad01a6a8da)

