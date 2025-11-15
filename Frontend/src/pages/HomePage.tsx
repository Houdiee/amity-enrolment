import { Box, Image } from "@chakra-ui/react";
import LogoImage from "../assets/amity_college_logo.png";

function HomePage() {
  return (
    <>
      <Box>
        <Image src={LogoImage} />
      </Box>
    </>
  );
}

export default HomePage;
