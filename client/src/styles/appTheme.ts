// src/layout/appTheme.ts
import { createTheme, alpha } from "@mui/material/styles";

export const appTheme = createTheme({
  palette: {
    mode: "dark",
    primary: {
      main: "#00aaff", // холодный неон
      light: "#33ccff",
      dark: "#0066ff",
      contrastText: "#ffffff",
    },
    secondary: {
      main: "#ff6600", // янтарный акцент
      light: "#ff944d",
      dark: "#b64200",
      contrastText: "#ffffff",
    },
    background: {
      default: "#0a0e17",
      paper: "rgba(15, 20, 30, 0.85)",
    },
    text: {
      primary: "#ffffff",
      secondary: "#94c5cc", // светло-голубой
    },
    info: { main: "#00aaff" },
    warning: { main: "#ffaa00" },
    error: { main: "#ff4444" },
    success: { main: "#00ff88" },
  },

  typography: {
    fontFamily: '"Orbitron", "Rajdhani", "Segoe UI", "Roboto", sans-serif',
    h1: {
      fontWeight: 900,
      fontSize: "clamp(2.8rem, 6vw, 4.5rem)",
      letterSpacing: "2px",
      textTransform: "uppercase",
    },
    h2: { fontWeight: 800, letterSpacing: "1.5px", textTransform: "uppercase" },
    h3: { fontWeight: 700, letterSpacing: "1px" },
    h4: { fontWeight: 600, letterSpacing: "1px" },
    h5: { fontWeight: 500, letterSpacing: "0.5px" },
    h6: { fontWeight: 500, letterSpacing: "0.5px" },
    button: {
      fontWeight: 700,
      textTransform: "uppercase",
      letterSpacing: "1.2px",
    },
  },
  shape: { borderRadius: 6 },
  components: {
    MuiCssBaseline: {
      styleOverrides: {
        body: {
          scrollbarWidth: "thin",
          scrollbarColor: "#0066ff #0a0e17",
          "&::-webkit-scrollbar": { width: 8 },
          "&::-webkit-scrollbar-track": { background: "#0a0e17" },
          "&::-webkit-scrollbar-thumb": {
            background: "linear-gradient(45deg, #0066ff, #ff4444)",
            borderRadius: 4,
          },
        },
        "@global": {
          "@keyframes gradientShift": {
            "0%": { backgroundPosition: "0% 50%" },
            "50%": { backgroundPosition: "100% 50%" },
            "100%": { backgroundPosition: "0% 50%" },
          },
          "@keyframes scanLine": {
            "0%": { transform: "translateY(0)" },
            "100%": { transform: "translateY(100vh)" },
          },
          "@keyframes pulseRed": {
            "0%, 100%": { opacity: 0.1 },
            "50%": { opacity: 0.3 },
          },
          "@keyframes pulseBlue": {
            "0%, 100%": { opacity: 0.1 },
            "50%": { opacity: 0.3 },
          },
        },
      },
    },
    MuiCard: {
      styleOverrides: {
        root: {
          background: `linear-gradient(145deg, rgba(10, 15, 30, 0.85), rgba(20, 25, 45, 0.75))`,
          border: "1px solid",
          borderColor: alpha("#00aaff", 0.2),
          backdropFilter: "blur(16px) saturate(120%)",
          borderRadius: "10px",
          boxShadow: `
        0 0 20px rgba(0, 170, 255, 0.15),
        0 0 10px rgba(255, 102, 0, 0.1),
        inset 0 1px 0 ${alpha("#fff", 0.05)}
      `,
          "&::before": {
            content: '""',
            position: "absolute",
            top: 0,
            left: 0,
            right: 0,
            height: "2px",
            background: "linear-gradient(90deg, #00aaff, #ff6600, #00aaff)",
          },
        },
      },
    },
    MuiButton: {
      styleOverrides: {
        root: {
          borderRadius: "4px",
          textTransform: "uppercase",
          fontWeight: 600,
          letterSpacing: "1px",
          transition: "all 0.3s ease",
          padding: "10px 24px",
          position: "relative",
          overflow: "hidden",
          "&::before": {
            content: '""',
            position: "absolute",
            top: 0,
            left: "-100%",
            width: "100%",
            height: "100%",
            background:
              "linear-gradient(90deg, transparent, rgba(255,255,255,0.2), transparent)",
            transition: "left 0.5s ease",
          },
          "&:hover::before": {
            left: "100%",
          },
        },
        contained: {
          background: "linear-gradient(45deg, #0066ff, #ff4444)",
          boxShadow: "0 4px 15px rgba(0, 102, 255, 0.3)",
          "&:hover": {
            background: "linear-gradient(45deg, #0055dd, #ff3333)",
            boxShadow:
              "0 6px 20px rgba(0, 102, 255, 0.4), 0 3px 10px rgba(255, 68, 68, 0.3)",
            transform: "translateY(-2px)",
          },
        },
        outlined: {
          borderColor: alpha("#0066ff", 0.5),
          color: "#00aaff",
          "&:hover": {
            borderColor: "#00aaff",
            background: alpha("#0066ff", 0.1),
            boxShadow: "0 0 15px rgba(0, 170, 255, 0.3)",
          },
        },
      },
    },
    MuiAppBar: {
      styleOverrides: {
        root: {
          background: "rgba(10, 14, 23, 0.9)",
          backdropFilter: "blur(20px)",
          borderBottom: `1px solid ${alpha("#0066ff", 0.3)}`,
          boxShadow: "0 2px 20px rgba(0, 102, 255, 0.2)",
        },
      },
    },
    MuiTextField: {
      styleOverrides: {
        root: {
          "& .MuiOutlinedInput-root": {
            borderRadius: "4px",
            background: alpha("#001a33", 0.7),
            border: "1px solid",
            borderColor: alpha("#0066ff", 0.3),
            transition: "all 0.3s ease",
            "&:hover": {
              borderColor: alpha("#00aaff", 0.5),
            },
            "&.Mui-focused": {
              borderColor: "#00aaff",
              boxShadow: "0 0 10px rgba(0, 170, 255, 0.3)",
            },
          },
        },
      },
    },
    MuiAlert: {
      styleOverrides: {
        root: {
          borderRadius: "4px",
          backdropFilter: "blur(10px)",
        },
        standardError: {
          background: alpha("#ff4444", 0.15),
          border: "1px solid",
          borderColor: alpha("#ff4444", 0.3),
          color: "#ff6666",
        },
        standardSuccess: {
          background: alpha("#00ff88", 0.15),
          border: "1px solid",
          borderColor: alpha("#00ff88", 0.3),
          color: "#66ffaa",
        },
        standardInfo: {
          background: alpha("#00aaff", 0.15),
          border: "1px solid",
          borderColor: alpha("#00aaff", 0.3),
          color: "#66ccff",
        },
        standardWarning: {
          background: alpha("#ffaa00", 0.15),
          border: "1px solid",
          borderColor: alpha("#ffaa00", 0.3),
          color: "#ffcc66",
        },
      },
    },
    MuiChip: {
      styleOverrides: {
        root: {
          fontWeight: 600,
          letterSpacing: "0.5px",
        },
        filled: {
          background: "linear-gradient(45deg, #0066ff, #ff4444)",
          color: "#ffffff",
        },
        outlined: {
          borderColor: alpha("#0066ff", 0.5),
          color: "#00aaff",
        },
      },
    },
  },
});
