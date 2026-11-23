# ADR-004: Evaluación periódica y notificación de una sola vez

- **Estado:** Aceptado
- **Contexto:** el mock de precios no publica eventos; las alertas deben funcionar con múltiples instancias sin duplicar notificaciones.
- **Decisión:** `IHostedService` evalúa cada 30 segundos, consulta alertas no disparadas y el servicio de precios. Un `UPDATE` condicional `IsTriggered = false` reclama cada alerta; dentro de la misma transacción solo el ganador crea la notificación persistida. Una alerta se dispara una sola vez aunque la condición continúe.
- **Consecuencias:** simplicidad y recuperación tras reinicio; la latencia máxima nominal es 30 s. Para muchas instancias, un scheduler distribuido (p. ej. Azure Functions/Quartz con lock compartido) evitaría consultas duplicadas; la transición y notificación transaccionales impiden duplicados y pérdidas parciales.
