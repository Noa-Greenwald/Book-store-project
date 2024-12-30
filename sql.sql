create database DN_project
use DN_project
CREATE TABLE Category (
    categoryId INT PRIMARY KEY,
    categoryName VARCHAR(255) NOT NULL
);
CREATE TABLE Company (
    companyId INT PRIMARY KEY,
    companyName VARCHAR(255) NOT NULL
);
CREATE TABLE Customer (
    customerId INT PRIMARY KEY,
    customerName VARCHAR(255) NOT NULL,
    phone BIGINT NOT NULL,
    email VARCHAR(255) NOT NULL,
    birthday DATE NOT NULL
);
CREATE TABLE Product (
    productId INT PRIMARY KEY,
    productName VARCHAR(255) NOT NULL,
    categoryId INT NOT NULL,
    companyId INT NOT NULL,
    description TEXT,
    matchAge INT,
    price DECIMAL(10, 2),
    picture VARCHAR(255),
    lastUpdatedDate DATETIME NOT NULL,
    FOREIGN KEY (categoryId) REFERENCES Category(categoryId),
    FOREIGN KEY (companyId) REFERENCES Company(companyId)
);
CREATE TABLE ProductInCart (
    productId INT NOT NULL,
    productName VARCHAR(255) NOT NULL,
    categoryId INT NOT NULL,
    companyId INT NOT NULL,
    description TEXT,
    matchAge INT,
    price DECIMAL(10, 2),
    picture VARCHAR(255),  -- נתיב לתמונה
    lastUpdatedDate DATETIME NOT NULL,
    quantity INT NOT NULL,
    totalPrice DECIMAL(10, 2),
    PRIMARY KEY (productId, quantity),
    FOREIGN KEY (categoryId) REFERENCES Category(categoryId),
    FOREIGN KEY (companyId) REFERENCES Company(companyId)
);
CREATE TABLE Purchase (
    purchaseId INT PRIMARY KEY,       -- מזהה רכישה ייחודי
    customerId INT NOT NULL,          -- מזהה לקוח
    purchaseDate DATETIME NOT NULL,   -- תאריך רכישה
    amountPay DECIMAL(10, 2) NOT NULL, -- סכום לתשלום
    remark VARCHAR(255),              -- הערה כלשהי על הרכישה
    FOREIGN KEY (customerId) REFERENCES Customer(customerId) -- קשר לטבלת לקוחות
);
CREATE TABLE PurchaseDetails (
    purchaseDetailsId INT PRIMARY KEY,        -- מזהה ייחודי לכל רשומת פרטי רכישה
    purchaseId INT NOT NULL,                  -- מזהה רכישה
    productId INT NOT NULL,                   -- מזהה המוצר
    quantity INT NOT NULL,                    -- כמות המוצר שנרכשה
    FOREIGN KEY (purchaseId) REFERENCES Purchase(purchaseId), -- קשר לטבלת רכישות (אם קיימת)
    FOREIGN KEY (productId) REFERENCES Product(productId)  -- קשר לטבלת מוצרים
);


ALTER TABLE product
DROP COLUMN amount;

---הכנסת נתונים
INSERT INTO Category (categoryId, categoryName)
VALUES
(1, 'מבוגרים'),
(2, 'נוער'),
(3, 'ילדים'),
(4, 'ספרי קודש');

INSERT INTO Company (companyId, companyName)
VALUES
(1, 'יפה נוף'),
(2, 'אור החיים'),
(3, 'מייזליק');

INSERT INTO Customer (customerId, customerName, phone, email, birthday)
VALUES
(1, 'יעל כהן', '050-1234567', 'yc123@gmail.com', '1985-05-15'),
(2, 'מרים מילר', '050-7654321', 'm54321@gmail.com', '1990-08-22'),
(3, 'מיכאל יעקבי', '050-1122334', 'michael@gmail.com', '1978-11-10');

INSERT INTO Product (productId, productName, categoryId, companyId, description, matchAge, price, picture, lastUpdatedDate)
VALUES
(1, 'קשר גורדי', 1, 1, 'ספר מתח ישראלי על חקירה ורצח', 14, 79.90, 'assets/images/thriller1.jpg', '1990-01-10'),
(2, 'סיפור ברובע', 1, 2, 'ספר לעומק הנפש', 20, 89.90, 'assets/images/adventure1.jpg', '2024-07-15'),
(3, 'המסע הארוך שך נאן', 2, 1, 'המסע של ילדה בתקופת השואה אצל סבתא שלה', 13, 59.90, 'assets/images/adventure2.jpg', '2023-11-25'),
(4, 'האסון של שלג', 3, 3, 'מדע בדיוני בעולם פוסט-אפוקליפטי', 15, 79.90, 'assets/images/scifi1.jpg', '2023-10-05'),
(5, 'המשחק של אנדר', 3, 2, 'סדרת מדע בדיוני עם קרב בין כוכבים', 16, 89.90, 'assets/images/scifi2.jpg', '2024-02-01'),
(6, 'הארי פוטר ואבן החכמים', 4, 1, 'ספר פנטזיה קסום על ילד עם כוחות מיוחדים', 13, 79.90, 'assets/images/fantasy1.jpg', '2024-01-15'),
(7, 'ההוביט', 1, 1, 'סיפור פנטזיה עם גיבור קטן בהרפתקאות גדולות', 12, 69.90, 'assets/images/fantasy2.jpg', '2023-12-01'),
(8, 'לחלום מחדש', 3, 1, 'דרמה משפחתית על בני נוער המתמודדים עם אתגרים', 16, 79.90, 'assets/images/drama1.jpg', '2023-11-10');

INSERT INTO Purchase (purchaseId, customerId, purchaseDate, amountPay, remark)
VALUES
(1, 1, '2024-12-07', 79.90, 'קניית הספר "קשר גורדי"'),
(2, 2, '2024-12-05', 99.90, 'קניית הספר "חבורת הסודי ביותר"'),
(3, 3, '2024-12-08', 89.90, 'קניית הספר "האסון של שלג"');

INSERT INTO productincart (productId, productName, categoryId, companyId, description, matchAge, price, picture, lastUpdatedDate, quantity, totalPrice)
VALUES
(1, 'קשר גורדי', 1, 1, 'ספר מתח ישראלי על חקירה ורצח', 14, 79.90, 'assets/images/thriller1.jpg', '2024-01-10', 1, 79.90),
(2, 'חבורת הסודי ביותר', 2, 5, 'סדרת הרפתקאות עם חידות ומסתורין', 12, 89.90, 'assets/images/adventure1.jpg', '2023-12-15', 2, 179.80),
(5, 'המשחק של אנדר', 3, 2, 'סדרת מדע בדיוני עם קרב בין כוכבים', 16, 89.90, 'assets/images/scifi2.jpg', '2024-02-01', 1, 89.90);

INSERT INTO Customer (customerId, customerName, phone, email, birthday) VALUES
(1, 'David Cohen', 972501234567, 'david.cohen@gmail.com', '1990-05-15'),
(2, 'Rivka Levi', 972503456789, 'rivka.levi@yahoo.com', '1985-11-22'),
(3, 'Eli Goldstein', 972523214567, 'eli.goldstein@outlook.com', '1992-03-12'),
(4, 'Sarah Mizrahi', 972543654321, 'sarah.mizrahi@gmail.com', '1988-07-08'),
(5, 'Noam Ben-Ami', 972556789123, 'noam.benami@walla.co.il', '1995-01-30');




ALTER TABLE Product ALTER COLUMN price FLOAT;
SELECT * FROM Product;
select * from Customer