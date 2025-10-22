// src/pages/LoginPage.tsx
import { useState, useEffect } from "react";
import {
  Box,
  Container,
  Card,
  TextField,
  Button,
  Typography,
  Alert,
  alpha,
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

interface LoginForm {
  email: string;
  password: string;
  showPassword: boolean;
}

// Локальные изображения
import authBg1 from "../assets/images/auth-bg-1.png";
import authBg2 from "../assets/images/auth-bg-2.png";
import authBg3 from "../assets/images/auth-bg-3.png";
import authBg4 from "../assets/images/auth-bg-4.png";
import authBg5 from "../assets/images/auth-bg-5.png";

const carImages = [authBg1, authBg2, authBg3, authBg4, authBg5];

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
        setError(
          "Неверный email или пароль. Попробуйте: demo@example.com / password"
        );
      }
    } catch (err) {
      setError("Ошибка при авторизации. Попробуйте еще раз.");
      console.error("Error during authorization:", err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <Box
      sx={{
        minHeight: "100vh",
        position: "relative",
        overflow: "hidden",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        background:
          "linear-gradient(135deg, #0a0e17 0%, #1a1a2a 50%, #250f0f 100%)",
      }}
    >
      {/* Фон с Battlefield-style фильтрами - УВЕЛИЧИМ ПРОЗРАЧНОСТЬ */}
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
            sx={{
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
              opacity: index === currentImageIndex ? 1 : 0,
              "&::before": {
                content: '""',
                position: "absolute",
                top: 0,
                left: 0,
                right: 0,
                bottom: 0,
                // УВЕЛИЧИВАЕМ ПРОЗРАЧНОСТЬ фонового фильтра
                background: `
                  linear-gradient(
                    135deg,
                    rgba(0, 100, 255, 0.2) 0%,    /* было 0.3 */
                    rgba(255, 50, 50, 0.15) 50%,   /* было 0.2 */
                    rgba(150, 0, 0, 0.2) 100%      /* было 0.3 */
                  )
                `,
                backdropFilter:
                  "contrast(1.1) saturate(1.1) blur(0.5px)" /* уменьшаем blur */,
              },
            }}
          />
        ))}

        {/* Анимированные сканеры - делаем более тонкими */}
        <Box
          sx={{
            position: "absolute",
            top: 0,
            left: 0,
            right: 0,
            height: "1px" /* было 2px */,
            background:
              "linear-gradient(90deg, transparent, #00aaff, #ff4444, transparent)",
            animation: "scanLine 4s linear infinite",
            boxShadow: "0 0 10px #00aaff, 0 0 5px #ff4444" /* уменьшаем тень */,
            opacity: 0.7,
            "@keyframes scanLine": {
              "0%": { transform: "translateY(0)" },
              "100%": { transform: "translateY(100vh)" },
            },
          }}
        />
      </Box>

      {/* Контент */}
      <Container
        maxWidth="sm"
        sx={{
          position: "relative",
          zIndex: 1,
          py: 4,
        }}
      >
        <Zoom in timeout={800}>
          <Card
            sx={{
              p: { xs: 3, sm: 4, md: 5 },
              // УВЕЛИЧИВАЕМ ПРОЗРАЧНОСТЬ основной карточки
              background: `
                linear-gradient(145deg, 
                  rgba(10, 15, 30, 0.7) 0%,     /* было 0.95 */
                  rgba(20, 25, 45, 0.65) 50%,   /* было 0.9 */
                  rgba(30, 15, 20, 0.6) 100%    /* было 0.85 */
                )
              `,
              border: "1px solid",
              borderColor: alpha("#0066ff", 0.4),
              backdropFilter:
                "blur(5px)" /* уменьшаем blur для большей прозрачности */,
              borderRadius: "8px",
              position: "relative",
              overflow: "hidden",
              boxShadow: `
                0 0 40px rgba(0, 102, 255, 0.3),   /* увеличиваем тень для лучшего выделения */
                0 0 20px rgba(255, 68, 68, 0.2),
                inset 0 1px 0 ${alpha("#fff", 0.1)},
                inset 0 -1px 0 ${alpha("#000", 0.2)}
              `,
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
            }}
          >
            {/* Заголовок */}
            <Box
              sx={{
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
                mb: 4,
                flexDirection: "column",
              }}
            >
              <Box
                sx={{
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
                }}
              >
                <Security sx={{ color: "#fff", fontSize: 40 }} />
              </Box>

              <GradientText
                variant="h3"
                sx={{
                  fontWeight: 800,
                  textAlign: "center",
                  mb: 1,
                  textShadow:
                    "0 0 30px rgba(0, 102, 255, 0.5), 0 0 15px rgba(255, 68, 68, 0.3)",
                  letterSpacing: "3px",
                  fontSize: { xs: "2rem", md: "2.5rem" },
                  background:
                    "linear-gradient(45deg, #0066ff, #ff4444, #ffffff)",
                }}
              >
                CARPARSER
              </GradientText>

              <Typography
                variant="h6"
                sx={{
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
                }}
              >
                SECURE ACCESS SYSTEM
              </Typography>
            </Box>

            {error && (
              <Fade in>
                <Alert
                  severity="error"
                  sx={{
                    mb: 3,
                    borderRadius: "4px",
                    background: alpha(
                      "#ff4444",
                      0.15
                    ) /* увеличиваем прозрачность */,
                    border: "1px solid",
                    borderColor: alpha("#ff4444", 0.4),
                    color: "#ff6666",
                    alignItems: "center",
                    backdropFilter: "blur(10px)",
                    boxShadow: "0 0 15px rgba(255, 68, 68, 0.2)",
                  }}
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
                  input: {
                    sx: {
                      borderRadius: "4px",
                      // УВЕЛИЧИВАЕМ ПРОЗРАЧНОСТЬ полей ввода
                      background: alpha("#001a33", 0.5) /* было 0.6 */,
                      border: "1px solid",
                      borderColor: alpha("#0066ff", 0.4),
                      color: "#ffffff",
                      "&:focus-within": {
                        background: alpha("#0066ff", 0.15) /* было 0.1 */,
                        borderColor: "#00aaff",
                        boxShadow: "0 0 15px rgba(0, 170, 255, 0.4)",
                      },
                      "&::placeholder": {
                        color: alpha("#fff", 0.6) /* делаем плейсхолдер ярче */,
                      },
                    },
                  },
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
                        sx={{
                          color: "#ff4444",
                          "&:hover": {
                            color: "#ff6666",
                            background: alpha("#ff4444", 0.1),
                          },
                        }}
                      >
                        {form.showPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  ),
                }}
                slotProps={{
                  input: {
                    sx: {
                      borderRadius: "4px",
                      background: alpha("#001a33", 0.5) /* было 0.6 */,
                      border: "1px solid",
                      borderColor: alpha("#0066ff", 0.4),
                      color: "#ffffff",
                      "&:focus-within": {
                        background: alpha("#0066ff", 0.15) /* было 0.1 */,
                        borderColor: "#00aaff",
                        boxShadow: "0 0 15px rgba(0, 170, 255, 0.4)",
                      },
                    },
                  },
                }}
              />

              <Button
                fullWidth
                type="submit"
                variant="outlined"
                disabled={loading}
                sx={{
                  py: 1.5,
                  borderRadius: "4px",
                  borderColor: alpha("#ff4444", 0.5),
                  color: "#ff4444",
                  fontWeight: 600,
                  textTransform: "uppercase",
                  letterSpacing: "1px",
                  background: alpha("#ff4444", 0.05) /* добавляем легкий фон */,
                  "&:hover": {
                    borderColor: "#ff6666",
                    background: alpha("#ff4444", 0.1),
                    boxShadow: "0 0 20px rgba(255, 68, 68, 0.3)",
                    transform: "translateY(-1px)",
                  },
                  transition: "all 0.3s ease",
                }}
              >
                LOGIN
              </Button>
            </form>
          </Card>
        </Zoom>

        <Fade in timeout={1200}>
          <Typography
            variant="body2"
            sx={{
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
            }}
          >
            CLASSIFIED SYSTEM // CARPARSER v2.0
          </Typography>
        </Fade>
      </Container>
    </Box>
  );
};

export default LoginPage;
