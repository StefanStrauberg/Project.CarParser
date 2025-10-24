// src/app/layouts/App.tsx
import { Box, CssBaseline, ThemeProvider } from "@mui/material";
import { Outlet } from "react-router-dom";
import AppHeader from "../../components/AppHeader";
import authBg1 from "../../assets/images/auth-bg-1.jpg";
import { appTheme } from "../../styles/appTheme";
import { appBackgroundStyles } from "../../styles/appBackgroundStyles";

function App() {
  return (
    <ThemeProvider theme={appTheme}>
      <CssBaseline />
      <AppHeader />
      <Box sx={appBackgroundStyles.root(authBg1)}>
        <Box sx={appBackgroundStyles.glassOverlay} />
        <Box sx={appBackgroundStyles.scanLine} />
        <Box sx={appBackgroundStyles.pulseRed} />
        <Box sx={appBackgroundStyles.pulseBlue} />
        <Box sx={appBackgroundStyles.contentWrapper}>
          <Outlet />
        </Box>
      </Box>
    </ThemeProvider>
  );
}

export default App;
