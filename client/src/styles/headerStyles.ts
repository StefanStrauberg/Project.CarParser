// src/components/AppHeader/headerStyles.ts
import type { Theme } from "@mui/material/styles";
import type { SxProps } from "@mui/material/styles";
import { alpha } from "@mui/material/styles";

export const headerStyles = {
  appBar: {
    background: alpha("#0a0e17", 0.95),
    backdropFilter: "blur(20px)",
    borderBottom: `1px solid ${alpha("#0066ff", 0.3)}`,
    boxShadow: "0 2px 30px rgba(0, 102, 255, 0.2)",
  } as SxProps<Theme>,

  logoBox: {
    background: "linear-gradient(45deg, #0066ff, #ff4444)",
    borderRadius: "4px",
    p: 1,
    boxShadow: "0 0 15px rgba(0, 102, 255, 0.4)",
    position: "relative",
    "&::after": {
      content: '""',
      position: "absolute",
      top: 1,
      left: 1,
      right: 1,
      bottom: 1,
      border: "1px solid rgba(255, 255, 255, 0.3)",
      borderRadius: "2px",
    },
  } as SxProps<Theme>,

  titleText: {
    fontWeight: 700,
    cursor: "pointer",
    letterSpacing: "1px",
    textShadow: "0 0 20px rgba(0, 102, 255, 0.5)",
  } as SxProps<Theme>,

  navDesktop: {
    display: { xs: "none", md: "flex" },
    alignItems: "center",
    gap: 1,
  } as SxProps<Theme>,

  navMobile: {
    display: { xs: "flex", md: "none" },
    gap: 1,
    overflowX: "auto",
    py: 1,
    px: 1,
  } as SxProps<Theme>,

  navButton: (active: boolean): SxProps<Theme> => ({
    transition: "all 0.3s ease",
    background: active ? alpha("#0066ff", 0.2) : "transparent",
    border: active
      ? `1px solid ${alpha("#0066ff", 0.4)}`
      : "1px solid transparent",
    borderRadius: "4px",
    px: 2,
    py: 0.8,
    fontSize: "0.75rem",
    fontWeight: 600,
    letterSpacing: "0.5px",
    minWidth: "auto",
    "&:hover": {
      background: alpha("#0066ff", 0.15),
      borderColor: alpha("#00aaff", 0.5),
      transform: "translateY(-1px)",
      boxShadow: "0 4px 12px rgba(0, 102, 255, 0.3)",
    },
  }),

  navButtonMobile: (active: boolean): SxProps<Theme> => ({
    flexShrink: 0,
    transition: "all 0.3s ease",
    background: active ? alpha("#0066ff", 0.2) : "transparent",
    border: active
      ? `1px solid ${alpha("#0066ff", 0.4)}`
      : "1px solid transparent",
    borderRadius: "3px",
    px: 1.5,
    fontSize: "0.7rem",
    fontWeight: 600,
    letterSpacing: "0.3px",
    minHeight: "32px",
    "&:hover": {
      background: alpha("#0066ff", 0.15),
    },
  }),

  authButton: (isAuthenticated: boolean): SxProps<Theme> => ({
    ml: 2,
    background: isAuthenticated
      ? "linear-gradient(45deg, #00ff88, #00cc66)"
      : "linear-gradient(45deg, #0066ff, #ff4444)",
    color: "white",
    "&:hover": {
      transform: "translateY(-2px)",
      boxShadow: "0 8px 20px rgba(0, 102, 255, 0.4)",
    },
    transition: "all 0.3s ease",
    border: `1px solid ${alpha("#fff", 0.2)}`,
  }),
};
