export function asyncDelay(ms: number) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

export function delay(ms: number,action: () => void) {
  setTimeout(() => {
    action()
  }, ms)
}
