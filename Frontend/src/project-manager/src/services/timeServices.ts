export function asyncDelay(ms: number) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

export async function delay(ms: number) {
  let prom = new Promise(resolve => setTimeout(resolve, ms));
  await prom;
}
