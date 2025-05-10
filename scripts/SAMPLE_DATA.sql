
INSERT INTO "Autores" ("NombreCompleto", "FechaNacimiento", "CiudadProcedencia", "CorreoElectronico")
VALUES 
('Gabriel García Márquez', '1927-03-06', 'Aracataca', 'gabriel@example.com'),
('Isabel Allende', '1942-08-02', 'Lima', 'isabel@example.com'),
('Mario Vargas Llosa', '1936-03-28', 'Arequipa', 'mario@example.com'),
('Julio Cortázar', '1914-08-26', 'Bruselas', 'julio@example.com'),
('Laura Esquivel', '1950-09-30', 'Ciudad de México', 'laura@example.com');


INSERT INTO "Libros" ("Titulo", "Anio", "Genero", "NumeroPaginas", "AutorId")
VALUES 
('Cien años de soledad', 1967, 'Novela', 471, 1),
('El amor en los tiempos del cólera', 1985, 'Novela', 348, 1),

('La casa de los espíritus', 1982, 'Novela', 433, 2),
('Paula', 1994, 'Memorias', 384, 2),

('La ciudad y los perros', 1963, 'Novela', 336, 3),
('La fiesta del chivo', 2000, 'Novela', 518, 3),

('Rayuela', 1963, 'Novela', 600, 4),
('Bestiario', 1951, 'Cuento', 160, 4),

('Como agua para chocolate', 1989, 'Novela', 256, 5),
('Tan veloz como el deseo', 2001, 'Novela', 224, 5);
