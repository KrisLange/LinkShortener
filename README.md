# KrisLange.UrlShortener - ASP.NET Core 3.0 Server

This is an API for a Link Shortening Service

## Run

Linux/OS X:

```
sh build.sh
```

Windows:

```
build.bat
```

## Run in Docker

```
cd src/KrisLange.UrlShortener
docker build -t krislange.urlshortener .
docker run -p 5000:5000 krislange.urlshortener
```
