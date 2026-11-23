# ADR-005: JWT stateless y revocación en Redis

- **Estado:** Aceptado
- **Contexto:** varias instancias API/gateway, revocación antes de que expire un token.
- **Decisión:** JWT firmado HMAC, 30 min, issuer/audience/sig/exp validados, `jti` único. Logout guarda `revoked:{jti}` en Redis hasta expiración; API valida la lista distribuida en `OnTokenValidated`. No hay sesiones ni caché local.
- **Consecuencias:** Redis es dependencia para autenticar solicitudes; si no está disponible la validación falla en forma cerrada. La clave demo es solo local; producción requiere secreto administrado (Key Vault), rotación y claves asimétricas. No se incluyen saldos ni datos financieros en el token.
