// src/components/AppHeader/index.tsx
import { AppBar, Toolbar, Box, Button, IconButton } from "@mui/material";
import { CarRental, AccountCircle, MilitaryTech } from "@mui/icons-material";
import { useLocation, useNavigate } from "react-router-dom";
import GradientText from "../GradientText";
import { useEffect, useState } from "react";
import { headerStyles } from "../../styles/headerStyles";

const AppHeader = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    setIsAuthenticated(localStorage.getItem("isAuthenticated") === "true");
  }, []);

  const tabs = [
    { key: "/", label: "VEHICLE DATABASE" },
    { key: "/engine-types", label: "ENGINE SYSTEMS" },
    { key: "/place-cities", label: "LOCATION DATA" },
    { key: "/place-regions", label: "REGION MAP" },
    { key: "/transmission-types", label: "TRANSMISSION" },
  ];

  const isActiveTab = (path: string) => {
    if (path === "/") {
      return location.pathname === "/";
    }
    return location.pathname.startsWith(path);
  };

  const handleAuthClick = () => {
    if (isAuthenticated) {
      localStorage.removeItem("isAuthenticated");
      window.location.reload();
    } else {
      navigate("/login");
    }
  };

  return (
    <AppBar position="sticky" elevation={0} sx={headerStyles.appBar}>
      <Toolbar>
        <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
          <Box sx={headerStyles.logoBox}>
            <CarRental sx={{ color: "#fff", fontSize: 28 }} />
          </Box>
          <GradientText
            variant="h6"
            sx={headerStyles.titleText}
            onClick={() => navigate("/")}
          >
            CARPARSER
          </GradientText>
        </Box>

        <Box sx={{ flexGrow: 1 }} />

        <Box sx={headerStyles.navDesktop}>
          {tabs.map((tab) => (
            <Button
              key={tab.key}
              color="inherit"
              onClick={() => navigate(tab.key)}
              sx={headerStyles.navButton(isActiveTab(tab.key))}
            >
              {tab.label}
            </Button>
          ))}
        </Box>

        <IconButton
          onClick={handleAuthClick}
          sx={headerStyles.authButton(isAuthenticated)}
        >
          {isAuthenticated ? <MilitaryTech /> : <AccountCircle />}
        </IconButton>
      </Toolbar>

      <Toolbar sx={headerStyles.navMobile}>
        {tabs.map((tab) => (
          <Button
            key={tab.key}
            color="inherit"
            size="small"
            onClick={() => navigate(tab.key)}
            sx={headerStyles.navButtonMobile(isActiveTab(tab.key))}
          >
            {tab.label.split(" ")[0]}
          </Button>
        ))}
      </Toolbar>
    </AppBar>
  );
};

export default AppHeader;
