SGI App

SGI App es una aplicación desarrollada en C# que implementa una arquitectura limpia y modular, siguiendo los principios de Clean Architecture. El proyecto está estructurado en capas bien definidas, lo que facilita su mantenimiento, escalabilidad y pruebas.
📁 Estructura del Proyecto

El repositorio está organizado en las siguientes carpetas principales:

    application/: Contiene la lógica de negocio y los casos de uso de la aplicación.

    domain/: Define las entidades del dominio y las interfaces que representan los contratos del negocio.

    infrastructure/: Implementa los detalles técnicos, como el acceso a datos y servicios externos.

Además, incluye archivos esenciales para la configuración y ejecución del proyecto:

    Program.cs: Punto de entrada de la aplicación.

    sgi-app.csproj: Archivo de proyecto de C# que define las dependencias y configuraciones.

    sgi-app.sln: Solución que agrupa los diferentes proyectos del repositorio.

🛠️ Tecnologías Utilizadas

    Lenguaje: C# (.NET)

    Arquitectura: Clean Architecture

    Base de Datos: PostgreSQL (según la presencia de código PLpgSQL)

    Control de Versiones: Git

🚀 Cómo Ejecutar el Proyecto

    Clonar el repositorio:

git clone https://github.com/juandacf/sgi-app.git
cd sgi-app

Restaurar las dependencias:

dotnet restore

Compilar la solución:

dotnet build

Ejecutar la aplicación:

    dotnet run

    Asegúrate de tener configurada la cadena de conexión a la base de datos en el archivo de configuración correspondiente.

✅ Estado del Proyecto

    Commits: 68

    Contribuidores:

        juandacf (Juan David Caballero Fuentes)

        sebastianVis (Sebastián Visbal)

    Lenguajes:

        C#: 99.6%

        PLpgSQL: 0.4%

🤝 Contribuciones

Las contribuciones son bienvenidas. Si deseas colaborar:

    Haz un fork del repositorio.

    Crea una nueva rama para tu funcionalidad (git checkout -b nueva-funcionalidad).

    Realiza tus cambios y haz commit (git commit -am 'Agrega nueva funcionalidad').

    Sube tu rama (git push origin nueva-funcionalidad).

    Abre un Pull Request.

📄 Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo LICENSE para más detalles.
