// src/app/layouts/App.tsx
import {
  Box,
  createTheme,
  CssBaseline,
  ThemeProvider,
  alpha,
} from "@mui/material";
import { Outlet } from "react-router-dom";
import AppHeader from "../../components/AppHeader";

// Импортируем фоновое изображение
import authBg1 from "../../assets/images/auth-bg-1.png";

// Battlefield 3 inspired theme
const theme = createTheme({
  palette: {
    mode: "dark",
    primary: {
      main: "#0066ff",
      light: "#00aaff",
      dark: "#0055dd",
      contrastText: "#ffffff",
    },
    secondary: {
      main: "#ff4444",
      light: "#ff6666",
      dark: "#dd3333",
      contrastText: "#ffffff",
    },
    background: {
      default: "#0a0e17",
      paper: "rgba(20, 25, 45, 0.9)",
    },
    text: {
      primary: "#ffffff",
      secondary: "#00aaff",
    },
    error: {
      main: "#ff4444",
      light: "#ff6666",
    },
    warning: {
      main: "#ffaa00",
    },
    info: {
      main: "#00aaff",
    },
    success: {
      main: "#00ff88",
    },
  },
  typography: {
    fontFamily:
      '"Orbitron", "Inter", "Roboto", "Helvetica", "Arial", sans-serif',
    h1: {
      fontWeight: 800,
      fontSize: "clamp(2.5rem, 5vw, 4rem)",
      letterSpacing: "2px",
    },
    h2: {
      fontWeight: 700,
      letterSpacing: "1.5px",
    },
    h3: {
      fontWeight: 600,
      letterSpacing: "1px",
    },
    h4: {
      fontWeight: 600,
      letterSpacing: "1px",
    },
    h5: {
      fontWeight: 500,
      letterSpacing: "0.5px",
    },
    h6: {
      fontWeight: 500,
      letterSpacing: "0.5px",
    },
    button: {
      fontWeight: 600,
      textTransform: "uppercase",
      letterSpacing: "1px",
    },
  },
  shape: {
    borderRadius: 6,
  },
  components: {
    MuiCssBaseline: {
      styleOverrides: {
        body: {
          scrollbarWidth: "thin",
          scrollbarColor: "#0066ff #0a0e17",
          "&::-webkit-scrollbar": {
            width: 8,
          },
          "&::-webkit-scrollbar-track": {
            background: "#0a0e17",
          },
          "&::-webkit-scrollbar-thumb": {
            background: "linear-gradient(45deg, #0066ff, #ff4444)",
            borderRadius: 4,
          },
        },
      },
    },
    MuiCard: {
      styleOverrides: {
        root: {
          background: `
            linear-gradient(145deg, 
              rgba(10, 15, 30, 0.85) 0%,
              rgba(20, 25, 45, 0.8) 50%,
              rgba(30, 15, 20, 0.75) 100%
            )
          `,
          border: "1px solid",
          borderColor: alpha("#0066ff", 0.3),
          backdropFilter: "blur(20px)",
          borderRadius: "8px",
          position: "relative",
          overflow: "hidden",
          boxShadow: `
            0 0 30px rgba(0, 102, 255, 0.2),
            0 0 15px rgba(255, 68, 68, 0.1),
            inset 0 1px 0 ${alpha("#fff", 0.1)}
          `,
          "&::before": {
            content: '""',
            position: "absolute",
            top: 0,
            left: 0,
            right: 0,
            height: "2px",
            background: "linear-gradient(90deg, #0066ff, #ff4444, #0066ff)",
            borderRadius: "8px 8px 0 0",
          },
          "&:hover": {
            transform: "translateY(-4px)",
            boxShadow: `
              0 8px 40px rgba(0, 102, 255, 0.3),
              0 4px 20px rgba(255, 68, 68, 0.2),
              inset 0 1px 0 ${alpha("#fff", 0.1)}
            `,
            borderColor: alpha("#00aaff", 0.5),
          },
          transition: "all 0.3s cubic-bezier(0.4, 0, 0.2, 1)",
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
          background: "rgba(10, 14, 23, 0.9)", // Делаем более прозрачным для фона
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

function App() {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <AppHeader />
      <Box
        sx={{
          minHeight: "100vh",
          position: "relative",
          overflow: "hidden",
          // Основной фон с изображением автомобиля
          backgroundImage: `url(${authBg1})`,
          backgroundSize: "cover",
          backgroundPosition: "center",
          backgroundRepeat: "no-repeat",
          backgroundAttachment: "fixed", // Фиксируем фон при скролле
          "&::before": {
            content: '""',
            position: "absolute",
            top: 0,
            left: 0,
            right: 0,
            bottom: 0,
            // Battlefield-style фильтр поверх изображения
            background: `
              linear-gradient(
                135deg,
                rgba(0, 100, 255, 0.25) 0%,
                rgba(255, 50, 50, 0.15) 50%,
                rgba(150, 0, 0, 0.2) 100%
              ),
              radial-gradient(circle at 20% 80%, rgba(0, 102, 255, 0.2) 0%, transparent 50%),
              radial-gradient(circle at 80% 20%, rgba(255, 68, 68, 0.15) 0%, transparent 50%)
            `,
            backdropFilter: "contrast(1.1) saturate(1.1) blur(0.5px)",
            pointerEvents: "none",
          },
          "&::after": {
            content: '""',
            position: "absolute",
            top: 0,
            left: 0,
            right: 0,
            bottom: 0,
            // Технологичный overlay с сеткой
            background: `
              linear-gradient(90deg, 
                transparent 0%, 
                rgba(0, 100, 255, 0.03) 50%, 
                transparent 100%
              ),
              linear-gradient(0deg, 
                transparent 0%, 
                rgba(255, 50, 50, 0.02) 50%, 
                transparent 100%
            )`,
            backgroundSize: "60px 60px",
            opacity: 0.3,
            pointerEvents: "none",
          },
        }}
      >
        {/* Анимированные сканеры в стиле Battlefield */}
        <Box
          sx={{
            position: "absolute",
            top: 0,
            left: 0,
            right: 0,
            height: "1px",
            background:
              "linear-gradient(90deg, transparent, #00aaff, #ff4444, transparent)",
            animation: "scanLine 12s linear infinite",
            boxShadow: "0 0 8px #00aaff, 0 0 4px #ff4444",
            opacity: 0.4,
            zIndex: 1,
            "@keyframes scanLine": {
              "0%": { transform: "translateY(0)" },
              "100%": { transform: "translateY(100vh)" },
            },
          }}
        />

        {/* Дополнительные сканеры для глубины */}
        <Box
          sx={{
            position: "absolute",
            top: "30%",
            left: 0,
            right: 0,
            height: "1px",
            background:
              "linear-gradient(90deg, transparent, #ff4444, transparent)",
            animation: "pulseRed 8s ease-in-out infinite",
            opacity: 0.2,
            zIndex: 1,
            "@keyframes pulseRed": {
              "0%, 100%": { opacity: 0.1 },
              "50%": { opacity: 0.3 },
            },
          }}
        />

        <Box
          sx={{
            position: "absolute",
            top: "60%",
            left: 0,
            right: 0,
            height: "1px",
            background:
              "linear-gradient(90deg, transparent, #00aaff, transparent)",
            animation: "pulseBlue 6s ease-in-out infinite 2s",
            opacity: 0.2,
            zIndex: 1,
            "@keyframes pulseBlue": {
              "0%, 100%": { opacity: 0.1 },
              "50%": { opacity: 0.3 },
            },
          }}
        />

        {/* Контент поверх эффектов */}
        <Box
          sx={{
            position: "relative",
            zIndex: 2,
            minHeight: "100vh",
          }}
        >
          <Outlet />
        </Box>
      </Box>
    </ThemeProvider>
  );
}

export default App;
