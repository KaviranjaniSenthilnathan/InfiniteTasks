

&#x09;					  **DAY 4 - NORMALIZATION WORKSHEET**



=========================================================

**UNNORMALIZED FORM (UNF)**

=========================================================



**Customer Order Table**



+---------+--------------+-------------+-------------------+

| OrderID | CustomerName | Phone       | Products          |

+---------+--------------+-------------+-------------------+

| 001     | Nitish       | 9876543210  | Laptop, Mouse     |

| 002     | Athul        | 9876543211  | Keyboard, Monitor |

+---------+--------------+-------------+-------------------+



**Issues:**

1\. Multiple products stored in a single column.

2\. Repeating data.

3\. Difficult to update and maintain.



=========================================================

**FIRST NORMAL FORM (1NF)**

=========================================================



Rule:

Each column must contain only one value.



+---------+--------------+-------------+-------------+

| OrderID | CustomerName | Phone       | ProductName |

+---------+--------------+-------------+-------------+

| 001     | Nitish       | 9876543210  | Laptop      |

| 001     | Nitish       | 9876543210  | Mouse       |

| 002     | Athul        | 9876543211  | Keyboard    |

| 002     | Athul        | 9876543211  | Monitor     |

+---------+--------------+-------------+-------------+



Result:

\- Repeating groups removed.

\- Atomic values achieved.



=========================================================

**SECOND NORMAL FORM (2NF)**

=========================================================



Rule:

Must be in 1NF and remove partial dependency.



**CUSTOMERS**



+------------+--------------+-------------+

| CustomerID | CustomerName | Phone       |

+------------+--------------+-------------+

| C001       | Nitish       | 9876543210  |

| C002       | Athul        | 9876543211  |

+------------+--------------+-------------+



**ORDERS**



+---------+------------+

| OrderID | CustomerID |

+---------+------------+

| 001     | C001       |

| 002     | C002       |

+---------+------------+



**PRODUCTS**



+-----------+-------------+

| ProductID | ProductName |

+-----------+-------------+

| P001      | Laptop      |

| P002      | Mouse       |

| P003      | Keyboard    |

| P004      | Monitor     |

+-----------+-------------+



**ORDERDETAILS**



+---------+-----------+

| OrderID | ProductID |

+---------+-----------+

| 001     | P001      |

| 001     | P002      |

| 002     | P003      |

| 002     | P004      |

+---------+-----------+



Result:

\- Customer data separated.

\- Product data separated.

\- Redundancy reduced.



=========================================================

**THIRD NORMAL FORM (3NF)**

=========================================================



Rule:

Must be in 2NF and remove transitive dependency.



**CUSTOMERS**



+------------+--------------+--------------------+-------------+

| CustomerID | CustomerName | Email              | Phone       |

+------------+--------------+--------------------+-------------+

| C001       | Nitish       | nitish@gmail.com   | 9876543210  |

| C002       | Athul        | athul@gmail.com    | 9876543211  |

+------------+--------------+--------------------+-------------+



**PRODUCTS**



+-----------+-------------+--------+-------------+

| ProductID | ProductName | Price  | Category    |

+-----------+-------------+--------+-------------+

| P001      | Laptop      | 50000  | Electronics |

| P002      | Mouse       | 500    | Accessories |

| P003      | Keyboard    | 1000   | Accessories |

| P004      | Monitor     | 8000   | Electronics |

+-----------+-------------+--------+-------------+



**ORDERS**



+---------+------------+-------------+

| OrderID | CustomerID | OrderDate   |

+---------+------------+-------------+

| 001     | C001       | 10-Jul-2026 |

| 002     | C002       | 11-Jul-2026 |

+---------+------------+-------------+



**ORDERDETAILS**



+---------------+---------+-----------+----------+

| OrderDetailID | OrderID | ProductID | Quantity |

+---------------+---------+-----------+----------+

| 1             | 001     | P001      | 1        |

| 2             | 001     | P002      | 2        |

| 3             | 002     | P003      | 1        |

| 4             | 002     | P004      | 1        |

+---------------+---------+-----------+----------+



**PAYMENTS**



+-----------+---------+--------+-------------+

| PaymentID | OrderID | Amount | PaymentMode |

+-----------+---------+--------+-------------+

| 1         | 001     | 51000  | UPI         |

| 2         | 002     | 9000   | Card        |

+-----------+---------+--------+-------------+



Result:

\- Fully normalized database.

\- No partial dependency.

\- No transitive dependency.



=========================================================

**KEYS**

=========================================================



**Primary Keys**

\------------

Customers      -> CustomerID

Products       -> ProductID

Orders         -> OrderID

OrderDetails   -> OrderDetailID

Payments       -> PaymentID



**Foreign Keys**

\------------

Orders.CustomerID

&#x20;   -> Customers.CustomerID



OrderDetails.OrderID

&#x20;   -> Orders.OrderID



OrderDetails.ProductID

&#x20;   -> Products.ProductID



Payments.OrderID

&#x20;   -> Orders.OrderID



=========================================================

**RELATIONSHIPS**

=========================================================



Customers     1 ------ M Orders



Orders        1 ------ M OrderDetails



Products      1 ------ M OrderDetails



Orders        1 ------ M Payments



=========================================================

**CONCLUSION**

=========================================================



UNF

\- Repeating values present.



1NF

\- Atomic values only.



2NF

\- Partial dependencies removed.



3NF

\- Transitive dependencies removed.



Benefits:

1\. Reduces data redundancy.

2\. Improves data integrity.

3\. Easier maintenance.

4\. Better database performance.

5\. Proper database design.



=========================================================

END OF WORKSHEET

=========================================================

