import { Flex, Image, Drawer, Button, Icon, useDisclosure, Portal, CloseButton, useBreakpointValue, Link, Stack } from "@chakra-ui/react";
import LogoDesktop from "../assets/amity_college_logo.png";
import LogoCompact from "../assets/amity_college_logo_compact.png";
import { RxHamburgerMenu } from "react-icons/rx";

function Logo() {
  const imageSource = useBreakpointValue({
    base: LogoCompact,
    md: LogoDesktop,
  });
  return (
    <Image
      src={imageSource}
      alt="Amity College Logo"
      h={{ base: "50px", md: "100px" }}
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
            <Drawer.Body>
              <Stack>
                <Link>Enrol</Link>
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
        wrap="wrap"
        mx="auto"
        p="4"
      >
        <Logo />
        <NavbarDrawer />
      </Flex>
    </>
  );
}

export default HomePage;
