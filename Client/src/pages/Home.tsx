import { useEffect, useState } from "react";
import axios from "axios";
import { Button } from "react-bootstrap";
import { ArrowRight } from "react-bootstrap-icons";

function Home() {
  const [courses, setCourses] = useState([]);

  useEffect(() => {
    async function fetchCourses() {
      const response = await axios.get("http://localhost:5034/api/courses");
      setCourses(response.data);
    }
    fetchCourses();
  }, []);

  return (
    <div>
      {courses.map((course: any) => {
        return (
          <div key={course.id}>
            <p>
              {course.id} - {course.title}
            </p>
          </div>
        );
      })}

      <Button variant="primary">
        <ArrowRight size={24} className="me-2" />
        Click me!
      </Button>
    </div>
  );
}

export default Home;
