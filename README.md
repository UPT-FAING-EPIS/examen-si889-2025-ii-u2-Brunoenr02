[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=21372755)

# OrderApp - Patrón Builder para Órdenes de Compra

## 📋 Descripción

Aplicación de ejemplo que implementa el **Patrón de Diseño Builder** para la creación flexible y legible de órdenes de compra. Este proyecto demuestra las mejores prácticas de programación orientada a objetos y diseño de software.

## 🎯 Objetivo

Refactorizar una clase de orden de compra con múltiples propiedades utilizando el patrón Builder, mejorando la legibilidad del código, facilitando el mantenimiento y proporcionando una API fluida para la creación de objetos complejos.

## 🏗️ Patrón Builder Implementado

### Ventajas del Patrón Builder

- **Inmutabilidad**: Los objetos `PurchaseOrder` son inmutables después de su creación
- **Valores por defecto**: Proporciona valores razonables sin necesidad de especificarlos
- **Interfaz fluida**: Permite encadenar métodos para una sintaxis más legible
- **Validación centralizada**: Todas las validaciones están en un solo lugar
- **Flexibilidad**: Fácil agregar nuevos parámetros sin romper código existente

### Estructura del Patrón

```
PurchaseOrder (Producto)
    └── Objeto inmutable con propiedades de solo lectura
    
PurchaseOrderBuilder (Constructor)
    ├── Constructor con campos obligatorios
    ├── Métodos With*() para configuración opcional
    └── Método Build() para crear el objeto final
```

## 📁 Estructura del Proyecto

```
examen-si889-2025-ii-u2-Brunoenr02/
│
├── src/
│   └── OrderApp/
│       ├── OrderApp.csproj           # Proyecto principal
│       ├── PurchaseOrder.cs          # Clase de orden de compra
│       └── PurchaseOrderBuilder.cs   # Builder pattern
│
├── tests/
│   └── OrderApp.Tests/
│       ├── OrderApp.Tests.csproj     # Proyecto de pruebas
│       └── PurchaseOrderTests.cs     # Pruebas unitarias
│
├── OrderApp.sln                      # Solución de Visual Studio
└── README.md                         # Este archivo
```

## 🚀 Tecnologías Utilizadas

- **.NET 7.0**: Framework de desarrollo
- **C# 11**: Lenguaje de programación
- **xUnit**: Framework de pruebas unitarias
- **Visual Studio Code**: IDE recomendado

## 💻 Requisitos Previos

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) o superior
- Editor de código (Visual Studio, VS Code, Rider, etc.)
- Git para control de versiones

## 🔧 Instalación y Configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/UPT-FAING-EPIS/examen-si889-2025-ii-u2-Brunoenr02.git
cd examen-si889-2025-ii-u2-Brunoenr02
```

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Compilar el proyecto

```bash
dotnet build
```

### 4. Ejecutar las pruebas

```bash
dotnet test
```

## 📖 Uso del Builder

### Ejemplo Básico

```csharp
// Orden con valores por defecto (Quantity=1, ShippingMethod="Estándar")
var order = new PurchaseOrderBuilder("Carlos Ruiz", "Tablet")
    .Build();
```

### Ejemplo con Configuración Completa

```csharp
// Orden con todas las opciones configuradas
var order = new PurchaseOrderBuilder("Lucía Gómez", "Smartphone")
    .WithQuantity(2)
    .WithShipping("Express")
    .WithGiftWrap()
    .WithNotes("Entregar en horario de oficina")
    .Build();

// Obtener resumen
string resumen = order.Summary();
```

### Ejemplo con Envoltura sin Notas

```csharp
// Orden con envoltura de regalo pero sin notas
var order = new PurchaseOrderBuilder("Pedro", "Monitor")
    .WithGiftWrap()
    .Build();
```

## 🧪 Pruebas Unitarias

El proyecto incluye 3 pruebas unitarias que validan:

1. **CrearOrdenBasica_DeberiaRetornarResumenCorrecto**: 
   - Verifica la creación con valores por defecto
   
2. **CrearOrdenConEnvolturaYNotas_DeberiaIncluirAmbos**: 
   - Valida la configuración completa de todas las opciones
   
3. **CrearOrdenSinNotas_DeberiaOmitirNotas**: 
   - Comprueba el manejo correcto de campos opcionales

### Ejecutar Pruebas

```bash
# Ejecutar todas las pruebas
dotnet test

# Ejecutar con salida detallada
dotnet test --verbosity detailed

# Ejecutar con cobertura de código
dotnet test --collect:"XPlat Code Coverage"
```

## 📊 Valores por Defecto

| Propiedad | Tipo | Valor por Defecto | Obligatorio |
|-----------|------|-------------------|-------------|
| CustomerName | string | - | ✅ Sí |
| Product | string | - | ✅ Sí |
| Quantity | int | 1 | ❌ No |
| ShippingMethod | string | "Estándar" | ❌ No |
| GiftWrap | bool | false | ❌ No |
| Notes | string | string.Empty | ❌ No |

## 📚 Documentación del Código

Todo el código está documentado utilizando **comentarios XML** de C# que incluyen:

- Descripciones de clases, métodos y propiedades
- Parámetros y valores de retorno
- Ejemplos de uso
- Excepciones que pueden lanzarse
- Notas y observaciones importantes

### Generar Documentación XML

```bash
dotnet build /p:GenerateDocumentationFile=true
```

## 🔄 Comandos Útiles

```bash
# Limpiar compilaciones anteriores
dotnet clean

# Compilar en modo Release
dotnet build --configuration Release

# Ejecutar la aplicación (si tuviera un punto de entrada)
dotnet run --project src/OrderApp

# Ver información del proyecto
dotnet list package
```

## 🎨 Patrones de Diseño Aplicados

### Builder Pattern
- **Propósito**: Separar la construcción de un objeto complejo de su representación
- **Beneficio**: Permite crear objetos paso a paso con una interfaz fluida
- **Implementación**: `PurchaseOrderBuilder` construye objetos `PurchaseOrder`

### Immutable Object Pattern
- **Propósito**: Crear objetos que no pueden ser modificados después de su creación
- **Beneficio**: Seguridad en hilos, prevención de efectos secundarios
- **Implementación**: Todas las propiedades de `PurchaseOrder` son de solo lectura

## 🤝 Contribuir

Si deseas contribuir al proyecto:

1. Fork el repositorio
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📝 Licencia

Este proyecto es parte de un examen académico de la Universidad Privada de Tacna.

## 👥 Autor

- **Estudiante**: Brunoenr02
- **Curso**: SI889 - Ingeniería de Software II
- **Institución**: Universidad Privada de Tacna - FAING - EPIS
- **Año**: 2025

## 📧 Contacto

Para preguntas o sugerencias, contactar a través del sistema de GitHub Issues.

---

⭐ Si este proyecto te fue útil, considera darle una estrella en GitHub
