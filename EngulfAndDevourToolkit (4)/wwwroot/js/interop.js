window.downloadFile = (fileName, base64Data, contentType) => {
    const link = document.createElement('a');
    link.href = `data:${contentType};base64,${base64Data}`;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};

window.renderExpenditureChart = (canvasId, labels, data) => {
    const ctx = document.getElementById(canvasId);
    if (window.myChart) window.myChart.destroy();
    window.myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Annual Projected Expenditure ($)',
                data: data,
                backgroundColor: '#0d6efd'
            }]
        },
        options: {
            responsive: true,
            scales: { y: { beginAtZero: true } }
        }
    });
};