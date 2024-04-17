import Home from "./pages/Home";
import { Route, Switch as Routes } from "react-router-dom";
import Login from "./pages/Login";

function App() {
  return (
    <Routes>
      <Route path="/" exact component={Home} />
      <Route path="/login" component={Login} />
    </Routes>
  );
}

export default App;
