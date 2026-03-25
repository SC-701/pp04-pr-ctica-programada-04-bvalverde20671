Middleware de ASP.NET Core 8 que consulta los perfiles (roles) del usuario

autenticado en la base de datos de seguridad y lo agrega como 'Claim'

al 'HttpContext.User'.



\## Paso 1 \_ Configurar el feed de GitHub Packages (una sola vez por maquina)



Crea un PAT en tu cuenta GitHub con scope 'read:packages', luego ejecuta:



'''powershell

dotnet nuget add source https://github.com/SC-701/pp04-pr-ctica-programada-04-bvalverde20671.git

\--name GitHub

\--username bvalverde20671

\--password 

\--store-password-in-clear-text

