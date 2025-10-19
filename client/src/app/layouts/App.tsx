import { createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { Outlet } from "react-router-dom";
import AppHeader from "../../components/AppHeader";

function App() {
  const theme = createTheme({
    palette: {
      primary: { main: "#2a73ff" },
      secondary: { main: "#4f8dff" },
    },
  });

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <AppHeader />
      <Outlet />
    </ThemeProvider>
  );
}

export default App;
