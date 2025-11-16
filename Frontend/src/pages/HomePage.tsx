import { Flex, Image, Drawer, Button, Icon, useDisclosure, Portal, CloseButton, Link, Stack, HStack } from "@chakra-ui/react";
import LogoImage from "../assets/amity_college_logo_compact.png";
import { RxHamburgerMenu } from "react-icons/rx";

function Logo() {
  return (
    <Image
      src={LogoImage}
      alt="Amity College Logo"
      h={{ base: "60px" }}
    />
  );
}

function NavbarDrawer() {
  const { open, onToggle } = useDisclosure();

  return (
    <Drawer.Root open={open} onOpenChange={onToggle} size="full">
      <Drawer.Trigger asChild>
        <Button variant="outline" size="sm">
          <Icon>
            <RxHamburgerMenu />
          </Icon>
        </Button>
      </Drawer.Trigger>
      <Portal>
        <Drawer.Backdrop />
        <Drawer.Positioner>
          <Drawer.Content>
            <Drawer.Header>
              <Drawer.Title display="flex" justifyContent="center">
                <Logo />
              </Drawer.Title>
            </Drawer.Header>
            <Drawer.Body display="flex" justifyContent="center" mt="2">
              <Stack gap="6">
                <Link display="block" fontSize="xl" textAlign="center">
                  Sign Up
                </Link>
                <Link fontSize="xl" display="block" textAlign="center">
                  Log In
                </Link>
                <Link
                  fontSize="xl"
                  bgColor="blue.600"
                  display="block"
                  textAlign="center"
                  p="2"
                  pl="5"
                  pr="5"
                  borderRadius="3xl"
                  boxShadow="xl"
                >
                  Enrol Now
                </Link>
              </Stack>
            </Drawer.Body>
            <Drawer.CloseTrigger asChild>
              <CloseButton size="md" />
            </Drawer.CloseTrigger>
          </Drawer.Content>
        </Drawer.Positioner>
      </Portal>
    </Drawer.Root>
  );
}

function HomePage() {
  return (
    <>
      <Flex
        as="nav"
        align="center"
        justify="space-between"
        mx="auto"
        p="4"
      >
        <Logo />
        <HStack fontSize="lg" gap="8">
          <Link>
            Sign Up
          </Link>
          <Link>
            Log In
          </Link>
          <Link
            bgColor="blue.600"
            p="2"
            pl="4"
            pr="4"
            borderRadius="3xl"
          >
            Enrol Now
          </Link>
        </HStack>
      </Flex>
    </>
  );
}

export default HomePage;
