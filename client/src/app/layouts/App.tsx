import { Box, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { Outlet } from "react-router-dom";
import AppHeader from "../../components/AppHeader";

// Выносим тему наружу, чтобы она не пересоздавалась при каждом рендере
const theme = createTheme({
  palette: {
    mode: "dark", // Добавляем dark mode для лучшего отображения градиентов
    primary: {
      main: "#2a73ff",
      light: "#4f8dff",
      dark: "#1a56d9",
    },
    secondary: {
      main: "#4f8dff",
    },
    background: {
      default: "#0f0f23",
      paper: "rgba(30, 30, 58, 0.6)",
    },
  },
  typography: {
    fontFamily: '"Inter", "Roboto", "Helvetica", "Arial", sans-serif',
  },
  shape: {
    borderRadius: 12,
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
          background:
            "linear-gradient(135deg, #0f0f23 0%, #1a1a2e 50%, #16213e 100%)",
          position: "relative",
          "&::before": {
            content: '""',
            position: "absolute",
            top: 0,
            left: 0,
            right: 0,
            bottom: 0,
            background: `
              radial-gradient(circle at 20% 80%, rgba(99, 102, 241, 0.15) 0%, transparent 50%),
              radial-gradient(circle at 80% 20%, rgba(236, 72, 153, 0.15) 0%, transparent 50%),
              radial-gradient(circle at 40% 40%, rgba(245, 158, 11, 0.1) 0%, transparent 50%)
            `,
            pointerEvents: "none",
          },
        }}
      >
        {/* Добавляем обертку для контента поверх псевдоэлемента */}
        <Box sx={{ position: "relative", zIndex: 1 }}>
          <Outlet />
        </Box>
      </Box>
    </ThemeProvider>
  );
}

export default App;
