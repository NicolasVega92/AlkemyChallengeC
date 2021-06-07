# AlkemyChallengeC

- POSTMAN DOC: https://documenter.getpostman.com/view/16009151/TzY68tTV
- Entrego Challenge de Disney en C# 
- El proyecto consta de un WebAPI donde cree y desarrolle las siguientes carpetas:
  -  **Controllers**: Se encuentran los metodos de los distintas peticiones HTTP de cada Entidad
  -  **Data**: Esta creado el contexto y la interfaz implementada para trabajar con la base de datos.
  -  **Dtos**: Estan creados los archivos que sirven como entidades para la respuesta de la API. Estan separados en Create / Read / Update para poder modificarlos a propio gusto en el futuro.
  -  **Migrations**: Codigo creado por la migración realizada con dotnet migrations
  -  **Models**: De cada Entidad utilizando DataAnnotations. Con dichos modelos se creo la carpeta Migrations
  -  **Profiles**: Contiene los mapeos de los modelos con la carpeta Dtos y su correspondiente lectura.
  -  **Startup**: Se modifico el metodo ConfigureServices(...) para poder conectar el contexto y los using correspondientes.


## Conceptos que no pude resolver en el tiempo que realice el challenge
- Tuve un inconveniente que descrubí avanzado el proyecto que fue al crear la BD y vincular las columnas de Peliculas con Personajes y Genero.
- Query param en los metodos edad y nombre de personajes.
- No hice la Autenticación.
- No hice el envío de mail.
- El trabajo no esta terminado. 

