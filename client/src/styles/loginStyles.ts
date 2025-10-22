// src/pages/loginStyles.ts
import { alpha } from "@mui/material/styles";
import type { SxProps } from "@mui/material/styles";
import type { Theme } from "@mui/material/styles";

export const styles = {
  root: {
    minHeight: "100vh",
    position: "relative",
    overflow: "hidden",
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
    background:
      "linear-gradient(135deg, #0a0e17 0%, #1a1a2a 50%, #250f0f 100%)",
  } as SxProps<Theme>,

  backgroundImage: (image: string, isVisible: boolean): SxProps<Theme> => ({
    position: "absolute",
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    backgroundImage: `url(${image})`,
    backgroundSize: "cover",
    backgroundPosition: "center",
    backgroundRepeat: "no-repeat",
    transition: "opacity 1.5s ease-in-out",
    opacity: isVisible ? 1 : 0,
    "&::before": {
      content: '""',
      position: "absolute",
      top: 0,
      left: 0,
      right: 0,
      bottom: 0,
      background: `linear-gradient(135deg,rgba(0, 100, 255, 0.2) 0%,rgba(255, 50, 50, 0.15) 50%,rgba(150, 0, 0, 0.2) 100%)`,
      backdropFilter: "contrast(1.1) saturate(1.1) blur(0.5px)",
    },
  }),

  scanLine: {
    position: "absolute",
    top: 0,
    left: 0,
    right: 0,
    height: "1px",
    background:
      "linear-gradient(90deg, transparent, #00aaff, #ff4444, transparent)",
    animation: "scanLine 4s linear infinite",
    boxShadow: "0 0 10px #00aaff, 0 0 5px #ff4444",
    opacity: 0.7,
    "@keyframes scanLine": {
      "0%": { transform: "translateY(0)" },
      "100%": { transform: "translateY(100vh)" },
    },
  },

  card: {
    p: { xs: 3, sm: 4, md: 5 },
    background: `linear-gradient(145deg, rgba(10, 15, 30, 0.7) 0%,rgba(20, 25, 45, 0.65) 50%,rgba(30, 15, 20, 0.6) 100%)`,
    border: "1px solid",
    borderColor: alpha("#0066ff", 0.4),
    backdropFilter: "blur(5px)",
    borderRadius: "8px",
    position: "relative",
    overflow: "hidden",
    boxShadow: `0 0 40px rgba(0, 102, 255, 0.3),0 0 20px rgba(255, 68, 68, 0.2),inset 0 1px 0 ${alpha(
      "#fff",
      0.1
    )},inset 0 -1px 0 ${alpha("#000", 0.2)}`,
    "&::before": {
      content: '""',
      position: "absolute",
      top: 0,
      left: 0,
      right: 0,
      height: "3px",
      background: "linear-gradient(90deg, #0066ff, #ff4444, #0066ff)",
      boxShadow:
        "0 0 15px rgba(0, 102, 255, 0.5), 0 0 8px rgba(255, 68, 68, 0.3)",
    },
  },

  iconBox: {
    background: "linear-gradient(45deg, #0066ff, #ff4444)",
    borderRadius: "4px",
    p: 2,
    mb: 3,
    boxShadow:
      "0 0 20px rgba(0, 102, 255, 0.4), 0 0 10px rgba(255, 68, 68, 0.3)",
    position: "relative",
    "&::after": {
      content: '""',
      position: "absolute",
      top: 2,
      left: 2,
      right: 2,
      bottom: 2,
      border: "1px solid rgba(255, 255, 255, 0.3)",
      borderRadius: "2px",
    },
  },

  gradientText: {
    fontWeight: 800,
    textAlign: "center",
    mb: 1,
    textShadow:
      "0 0 30px rgba(0, 102, 255, 0.5), 0 0 15px rgba(255, 68, 68, 0.3)",
    letterSpacing: "3px",
    fontSize: { xs: "2rem", md: "2.5rem" },
    background: "linear-gradient(45deg, #0066ff, #ff4444, #ffffff)",
  },

  subtitle: {
    color: "#00aaff",
    textAlign: "center",
    fontWeight: 600,
    textTransform: "uppercase",
    letterSpacing: "2px",
    fontSize: "0.9rem",
    textShadow: "0 0 10px rgba(0, 170, 255, 0.5)",
    background: alpha("#00aaff", 0.1),
    px: 2,
    py: 0.5,
    borderRadius: "4px",
  },

  alert: {
    mb: 3,
    borderRadius: "4px",
    background: alpha("#ff4444", 0.15),
    border: "1px solid",
    borderColor: alpha("#ff4444", 0.4),
    color: "#ff6666",
    alignItems: "center",
    backdropFilter: "blur(10px)",
    boxShadow: "0 0 15px rgba(255, 68, 68, 0.2)",
  },

  inputField: {
    borderRadius: "4px",
    background: alpha("#001a33", 0.5),
    border: "1px solid",
    borderColor: alpha("#0066ff", 0.4),
    color: "#ffffff",
    "&:focus-within": {
      background: alpha("#0066ff", 0.15),
      borderColor: "#00aaff",
      boxShadow: "0 0 15px rgba(0, 170, 255, 0.4)",
    },
    "&::placeholder": {
      color: alpha("#fff", 0.6),
    },
  },

  passwordToggle: {
    color: "#ff4444",
    "&:hover": {
      color: "#ff6666",
      background: alpha("#ff4444", 0.1),
    },
  },

  loginButton: {
    py: 1.5,
    borderRadius: "4px",
    borderColor: alpha("#ff4444", 0.5),
    color: "#ff4444",
    fontWeight: 600,
    textTransform: "uppercase",
    letterSpacing: "1px",
    background: alpha("#ff4444", 0.05),
    "&:hover": {
      borderColor: "#ff6666",
      background: alpha("#ff4444", 0.1),
      boxShadow: "0 0 20px rgba(255, 68, 68, 0.3)",
      transform: "translateY(-4px)",
      willChange: "transform",
    },
    transition: "all 0.3s ease",
  },

  footer: {
    textAlign: "center",
    mt: 3,
    color: alpha("#00aaff", 0.6),
    fontSize: "0.7rem",
    textTransform: "uppercase",
    letterSpacing: "1px",
    textShadow: "0 0 10px rgba(0, 170, 255, 0.3)",
    background: alpha("#00aaff", 0.05),
    px: 2,
    py: 1,
    borderRadius: "4px",
    backdropFilter: "blur(5px)",
  },
};
