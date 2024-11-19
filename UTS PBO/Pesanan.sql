create type reservation_status as enum ('Active','Canceled')

CREATE TABLE reservations (
    id SERIAL PRIMARY KEY,                      
    nomor_meja INT NOT NULL,                    
    tanggal TIMESTAMP NOT NULL,                
    nama_customer VARCHAR(100) NOT NULL,        
    makanan VARCHAR(100) NOT NULL,             
    minuman VARCHAR(100) NOT NULL,              
    harga NUMERIC(10, 2) NOT NULL,              
    status reservation_status DEFAULT 'Active'  
);
select * from reservations
