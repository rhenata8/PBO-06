CREATE TABLE makanan (
    id SERIAL PRIMARY KEY,
    nama_makanan VARCHAR(50) NOT NULL,
    harga INTEGER NOT NULL
);

CREATE TABLE minuman (
    id SERIAL PRIMARY KEY,
    nama_minuman VARCHAR(50) NOT NULL,
    harga INTEGER NOT NULL
);

-- Menambahkan data ke tabel makanan
INSERT INTO makanan (nama_makanan, harga)
VALUES 
('Nasi Goreng', 20000),
('Nasi Udang Cumi Asam Manis', 30000),
('Nasi Ayam Geprek', 20000),
('Nasi Ayam Black Paper', 30000),
('Kwietau', 25000),
('Mie Goreng', 20000),
('Lalapan Ayam Cabe Ijo', 20000),
('Koloke Ayam', 25000),
('Nasi Ayam Katsu', 25000);

INSERT INTO minuman (nama_minuman, harga)
VALUES 
('Es Teh', 10000),
('Es Jeruk', 10000),
('Es Coklat', 20000),
('Es Matcha', 20000),
('Redvelvet', 20000),
('Es Teler', 15000),
('Es Cappucino', 15000),
('Milkshake', 15000),
('Thai Tea', 18000);
