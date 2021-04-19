 CREATE TABLE vacations
(
  id INT AUTO_INCREMENT,
  destination VARCHAR(255) NOT NULL UNIQUE,
  length INT,
  price DECIMAL(6 , 2) NOT NULL,
  PRIMARY KEY (id)
);