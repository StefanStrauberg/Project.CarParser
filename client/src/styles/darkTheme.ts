import { alpha, createTheme } from "@mui/material";

export const darkTheme = createTheme({
  palette: {
    mode: "dark",
    primary: {
      main: "#6366f1",
      light: "#818cf8",
      dark: "#4338ca",
    },
    secondary: {
      main: "#ec4899",
      light: "#f472b6",
      dark: "#db2777",
    },
    background: {
      default: "linear-gradient(135deg, #0f0f23 0%, #1a1a2e 50%, #16213e 100%)",
      paper: "rgba(30, 30, 46, 0.8)",
    },
  },
  typography: {
    fontFamily: '"Inter", "Roboto", "Helvetica", "Arial", sans-serif',
    h1: {
      fontWeight: 800,
      fontSize: "clamp(2.5rem, 5vw, 4rem)",
    },
    h2: {
      fontWeight: 700,
    },
    h3: {
      fontWeight: 600,
    },
  },
  shape: {
    borderRadius: 16,
  },
  components: {
    MuiCard: {
      styleOverrides: {
        root: {
          background:
            "linear-gradient(145deg, rgba(30, 30, 58, 0.9) 0%, rgba(45, 27, 105, 0.9) 100%)",
          border: "1px solid",
          borderColor: alpha("#6366f1", 0.2),
          backdropFilter: "blur(20px)",
          borderRadius: "20px",
          position: "relative",
          overflow: "hidden",
          "&::before": {
            content: '""',
            position: "absolute",
            top: 0,
            left: 0,
            right: 0,
            height: "3px",
            background: "linear-gradient(90deg, #6366f1, #ec4899, #f59e0b)",
            borderRadius: "20px 20px 0 0",
          },
          "&:hover": {
            transform: "translateY(-8px)",
            boxShadow: "0 20px 40px rgba(99, 102, 241, 0.3)",
          },
          transition: "all 0.4s cubic-bezier(0.4, 0, 0.2, 1)",
        },
      },
    },
    MuiButton: {
      styleOverrides: {
        root: {
          borderRadius: "14px",
          textTransform: "none",
          fontWeight: 600,
          transition: "all 0.3s ease",
          padding: "12px 24px",
        },
      },
    },
    MuiAppBar: {
      styleOverrides: {
        root: {
          background: "rgba(26, 26, 46, 0.95)",
          backdropFilter: "blur(25px)",
          borderBottom: `1px solid ${alpha("#6366f1", 0.2)}`,
        },
      },
    },
  },
});
