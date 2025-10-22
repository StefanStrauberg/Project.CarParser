// src/constants/auth.ts
export const AUTH_CREDENTIALS = {
  email: "demo@example.com",
  password: "password",
} as const;

// src/constants/routes.ts
export const TABS = [
  { key: "/", label: "VEHICLE DATABASE" },
  { key: "/engine-types", label: "ENGINE SYSTEMS" },
  { key: "/place-cities", label: "LOCATION DATA" },
  { key: "/place-regions", label: "REGION MAP" },
  { key: "/transmission-types", label: "TRANSMISSION" },
] as const;
