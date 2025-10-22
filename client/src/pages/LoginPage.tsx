import { useState, useEffect } from "react";
import {
  Box,
  Container,
  Card,
  TextField,
  Button,
  Typography,
  Alert,
  Fade,
  Zoom,
  InputAdornment,
  IconButton,
} from "@mui/material";
import {
  Visibility,
  VisibilityOff,
  Email,
  Lock,
  Security,
  Warning,
} from "@mui/icons-material";
import { useNavigate } from "react-router-dom";
import GradientText from "../components/GradientText";
import { styles } from "../styles/loginStyles";

import authBg1 from "../assets/images/auth-bg-1.png";
import authBg2 from "../assets/images/auth-bg-2.png";
import authBg3 from "../assets/images/auth-bg-3.png";
import authBg4 from "../assets/images/auth-bg-4.png";
import authBg5 from "../assets/images/auth-bg-5.png";

const carImages = [authBg1, authBg2, authBg3, authBg4, authBg5];

interface LoginForm {
  email: string;
  password: string;
  showPassword: boolean;
}

const LoginPage = () => {
  const navigate = useNavigate();
  const [form, setForm] = useState<LoginForm>({
    email: "",
    password: "",
    showPassword: false,
  });
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);
  const [currentImageIndex, setCurrentImageIndex] = useState(0);

  useEffect(() => {
    const timer = setInterval(() => {
      setCurrentImageIndex((prev) => (prev + 1) % carImages.length);
    }, 5000);
    return () => clearInterval(timer);
  }, []);

  const handleChange =
    (field: keyof LoginForm) =>
    (event: React.ChangeEvent<HTMLInputElement>) => {
      setForm({ ...form, [field]: event.target.value });
      setError("");
    };

  const handleClickShowPassword = () => {
    setForm({ ...form, showPassword: !form.showPassword });
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    setLoading(true);
    setError("");
    try {
      await new Promise((resolve) => setTimeout(resolve, 1500));
      if (form.email === "demo@example.com" && form.password === "password") {
        localStorage.setItem("isAuthenticated", "true");
        navigate("/");
      } else {
        setError("Неверный email или пароль.");
      }
    } catch (err) {
      setError("Ошибка при авторизации. Попробуйте еще раз.");
      console.error("Error during authorization:", err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <Box sx={styles.root}>
      <Box
        sx={{
          position: "absolute",
          top: 0,
          left: 0,
          right: 0,
          bottom: 0,
          zIndex: 0,
        }}
      >
        {carImages.map((image, index) => (
          <Box
            key={index}
            sx={styles.backgroundImage(image, index === currentImageIndex)}
          />
        ))}
        <Box sx={styles.scanLine} />
      </Box>

      <Container maxWidth="sm" sx={{ position: "relative", zIndex: 1, py: 4 }}>
        <Zoom in timeout={800}>
          <Card sx={styles.card}>
            <Box
              sx={{
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
                mb: 4,
                flexDirection: "column",
              }}
            >
              <Box sx={styles.iconBox}>
                <Security sx={{ color: "#fff", fontSize: 40 }} />
              </Box>
              <GradientText variant="h3" sx={styles.gradientText}>
                CARPARSER
              </GradientText>
              <Typography variant="h6" sx={styles.subtitle}>
                SECURE ACCESS SYSTEM
              </Typography>
            </Box>

            {error && (
              <Fade in>
                <Alert
                  severity="error"
                  sx={styles.alert}
                  icon={<Warning sx={{ color: "#ff4444" }} />}
                >
                  <Typography sx={{ fontWeight: 600, fontSize: "0.9rem" }}>
                    {error}
                  </Typography>
                </Alert>
              </Fade>
            )}

            <form onSubmit={handleSubmit}>
              <TextField
                fullWidth
                label="EMAIL"
                type="email"
                value={form.email}
                onChange={handleChange("email")}
                required
                sx={{ mb: 3 }}
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <Email sx={{ color: "#00aaff" }} />
                    </InputAdornment>
                  ),
                }}
                slotProps={{
                  input: { sx: styles.inputField },
                }}
              />

              <TextField
                fullWidth
                label="PASSWORD"
                type={form.showPassword ? "text" : "password"}
                value={form.password}
                onChange={handleChange("password")}
                required
                sx={{ mb: 4 }}
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <Lock sx={{ color: "#00aaff" }} />
                    </InputAdornment>
                  ),
                  endAdornment: (
                    <InputAdornment position="end">
                      <IconButton
                        onClick={handleClickShowPassword}
                        edge="end"
                        sx={styles.passwordToggle}
                      >
                        {form.showPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  ),
                }}
                slotProps={{
                  input: { sx: styles.inputField },
                }}
              />

              <Button
                fullWidth
                type="submit"
                variant="outlined"
                disabled={loading}
                sx={styles.loginButton}
              >
                LOGIN
              </Button>
            </form>
          </Card>
        </Zoom>

        <Fade in timeout={1200}>
          <Typography variant="body2" sx={styles.footer}>
            CLASSIFIED SYSTEM // CARPARSER v2.0
          </Typography>
        </Fade>
      </Container>
    </Box>
  );
};

export default LoginPage;
