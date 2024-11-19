create type reservation_status as enum ('Active','Canceled')

CREATE TABLE reservations (
    id SERIAL PRIMARY KEY,                      -- ID unik untuk setiap reservasi
    nomor_meja INT NOT NULL,                    -- Nomor meja yang dipesan
    tanggal TIMESTAMP NOT NULL,                 -- Tanggal dan waktu reservasi
    nama_customer VARCHAR(100) NOT NULL,        -- Nama pelanggan
    makanan VARCHAR(100) NOT NULL,              -- Nama makanan yang dipesan
    minuman VARCHAR(100) NOT NULL,              -- Nama minuman yang dipesan
    harga NUMERIC(10, 2) NOT NULL,              -- Harga total (dengan desimal)
    status reservation_status DEFAULT 'Active'  -- Status reservasi, default 'Active'
);
select * from reservations