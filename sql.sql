CREATE TABLE Akun_admin (
	id SERIAL PRIMARY KEY,
	nama VARCHAR(100) NOT NULL,
	username VARCHAR(100) NOT NULL,
	password VARCHAR(100) NOT NULL
);

INSERT INTO Akun_admin (nama, username, password) VALUES
('Rhenata', 'Rhen123', 'akunrhe'),
('Nabila', 'Nab456', 'akunnab');

select * from Akun_admin