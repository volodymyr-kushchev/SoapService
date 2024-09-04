# SoapService
Simple ASP.NET Core WebAPI project with SOAP endpoint

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


# Some thoughts about SOAP
SOAP provides better support for transactional features compared to REST because of its built-in support for certain advanced protocols and standards that are specifically designed to handle complex transactions, reliability, and security in a distributed environment. Here’s how SOAP achieves this:

1. **WS-AtomicTransaction (WS-AT)**
WS-AtomicTransaction is a protocol used with SOAP that allows multiple web services to participate in a distributed transaction. This ensures that all parts of a transaction either commit or roll back together, maintaining consistency.
How It Helps: In a distributed system where multiple services need to coordinate actions (e.g., updating a database, sending a message, calling another service), WS-AT ensures that these actions are treated as a single atomic unit. If any part fails, the entire transaction can be rolled back.
2. **WS-ReliableMessaging**
WS-ReliableMessaging is a protocol that guarantees the delivery of messages between distributed systems. It ensures that messages are delivered exactly once, in order, and without duplication.
How It Helps: In scenarios where message delivery reliability is crucial, such as financial transactions or order processing, WS-ReliableMessaging ensures that messages are not lost or duplicated, which is critical for maintaining data integrity in transactions.
3. **WS-Security**
WS-Security is a protocol that provides security features like message integrity, confidentiality, and authentication. It supports encryption and digital signatures to secure messages exchanged between services.
How It Helps: In transactional systems where sensitive data is exchanged, WS-Security ensures that the transaction data is secure, preventing tampering, unauthorized access, or interception.
4. **Two-Phase Commit Protocol**
This is a pattern supported by SOAP-based systems where a transaction coordinator manages the transaction across multiple resources (e.g., databases, message queues). In the first phase, the coordinator asks all participants to prepare for the transaction. If all participants agree, the second phase commits the transaction; otherwise, it rolls back.
How It Helps: This protocol ensures that all parts of a transaction are consistent across the system, which is critical in distributed environments where different services may need to coordinate their actions as part of a larger transaction.

# Compare it with SAGA pattern
The SAGA pattern and WS-AtomicTransaction are both approaches to handling distributed transactions, but they are fundamentally different in their design and application. Here's how they relate to each other and whether you can implement the SAGA pattern with SOAP and WS-AtomicTransaction:

**Understanding the SAGA Pattern** </br>
SAGA Pattern: This is a design pattern used for managing distributed transactions that consist of multiple microservices or components. Unlike traditional two-phase commit protocols, the SAGA pattern breaks down a transaction into a series of smaller, isolated transactions. If any of these smaller transactions fail, compensating transactions are triggered to undo the previous steps, ensuring eventual consistency.
Eventual Consistency: The SAGA pattern accepts that distributed transactions may not be immediately consistent but ensures that they eventually reach a consistent state.
</br>
**Understanding WS-AtomicTransaction** </br>
WS-AtomicTransaction: This is a protocol used in SOAP-based services to handle distributed transactions with strict ACID (Atomicity, Consistency, Isolation, Durability) properties. It relies on a two-phase commit protocol, where all participants in the transaction must agree to commit or abort the transaction. If any participant cannot commit, the entire transaction is rolled back.
Immediate Consistency: WS-AtomicTransaction ensures that all parts of a transaction either succeed or fail together, maintaining immediate consistency across the system.
</br>
