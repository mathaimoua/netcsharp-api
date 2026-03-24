# Simple Table creation
-- Create Table
CREATE TABLE person (
  id SERIAL PRIMARY KEY,
  first_name VARCHAR(100) NOT NULL,
  last_name VARCHAR(100) NOT NULL,
  email VARCHAR(255) UNIQUE NOT NULL,
  phone VARCHAR(20),
  created_at TIMESTAMP DEFAULT NOW()
);

-- Practice data
INSERT INTO person (first_name, last_name, email, phone) VALUES
  ('Matt', 'Moua', 'matt@example.com', '651-555-0101'),
  ('Jane', 'Doe', 'jane@example.com', '612-555-0182'),
  ('John', 'Smith', 'john@example.com', '763-555-0144'); 
