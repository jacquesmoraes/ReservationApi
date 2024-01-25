
export function formatDateAndTime(date: Date, time: string) {
    const dateTime = new Date(date);
    const [hours, minutes] = time.split(':').map(Number);
    dateTime.setHours(hours, minutes);
    return dateTime.toISOString();
}