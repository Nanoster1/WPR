export function isSmallScreen(): boolean {
  const minWidth = 768//so small display
  return window.innerWidth < minWidth
}
