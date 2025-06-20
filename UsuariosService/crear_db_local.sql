CREATE DATABASE IF NOT EXISTS usuarios_db;

USE usuarios_db;

CREATE TABLE usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre_usuario VARCHAR(100) NOT NULL,
    password_hashed VARCHAR(255) NOT NULL
);
