CREATE TABLE Admin (
	id SERIAL PRIMARY KEY,
	nama VARCHAR(100) NOT NULL,
	username VARCHAR(100) NOT NULL,
	password VARCHAR(100) NOT NULL,
	no_telp VARCHAR(15) NOT NULL,
	email VARCHAR(100) NOT NULL
);

CREATE TYPE meja_status AS ENUM ('Tersedia', 'Terisi');

CREATE TABLE Data_Meja (
	id SERIAL PRIMARY KEY,
	Nomor_meja INT NOT NULL,
	Kapasitas INT NOT NULL,
	Lantai INT NOT NULL,
	Status meja_status NOT NULL
);


INSERT INTO Admin (nama, username, password, no_telp, email) VALUES
('Rhenata', 'Rhen123', 'akunrhe', '082345672345679', 'rhen@gmail.com'),
('Nabila', 'Nab456', 'akunnab', '08532456789234', 'nab@gmail.com');

INSERT INTO Data_meja (Nomor_meja, Kapasitas, Lantai, Status) VALUES
(001, 2, 2, 'Tersedia'),
(005, 4, 1, 'Terisi');

select * from Data_meja

select * from Admin